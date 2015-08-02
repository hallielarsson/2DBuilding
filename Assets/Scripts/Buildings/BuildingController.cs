using UnityEngine;
using System.Collections;
using System;

public class BuildingController : MapObject, INodeOccupant {
	
	public State moveStateIdle;
	public State moveStateMove;
	public State moveStateClean;
	public GameObject preview;
	public NodeManager nodeManager;


	public PlayerInput input; 
	PlayerMotor motor;
	
	public Vector2 moveDir = Vector2.zero;
	public readonly float moveSpeed = 10.0f;
	public StateMachine moveMachine = new StateMachine();
	// Use this for initialization
	void Start () {
		moveStateIdle = MakeIdleState ();
		moveStateMove = MakeMovingState ();
		moveMachine.BeginState(moveStateIdle);
		
		
		input = gameObject.AddComponent <TabletPlayerInput>();
		motor = gameObject.AddComponent <PlayerMotor>();
		//view = transform.FindChild("View").GetComponent <PlayerCharacterView>();
		motor.SetSpeed (moveSpeed);
	}

	void Update() {

	}
	
	public void Move(Vector2 pDir) {
		moveDir = pDir;
		motor.SetSpeed (moveSpeed);
		motor.SetDir (pDir);
		MapNodeScript closestNode = nodeManager.GetClosestNode (transform.position);
		preview.transform.position = closestNode.transform.position;
	}
	
	public void DetermineCurrentState(Vector2 pDir) {
		if (moveMachine.state == moveStateIdle && pDir.sqrMagnitude > 0.01) {
			moveMachine.BeginState (moveStateMove);
		} else if (moveMachine.state == moveStateMove && pDir.sqrMagnitude < 0.01) {
			moveMachine.BeginState (moveStateIdle);
		}	
	}
	

	/*state definitions */
	
	State MakeIdleState() {
		return new State (delegate {
		}, delegate {});
	}
	
	
	State MakeMovingState() {
		return new State (delegate {
			if(node != null) {
				node.RemoveOccupant(this);
			}
			preview.SetActive(true);
		}, delegate {
			node = nodeManager.GetClosestNode(transform.position);
			node.SetOccupant(this);
			transform.position = node.transform.position;
			preview.transform.localPosition = Vector3.zero;
			preview.SetActive(false);

		});
	}	

	/*nuts and bolts*/
	public void StartInput() {
		moveMachine.BeginState (moveStateMove);
		
	}
	
	public void EndInput() {
		moveMachine.BeginState (moveStateIdle);
	}



}