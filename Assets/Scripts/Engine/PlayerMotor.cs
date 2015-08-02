using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMotor : MonoBehaviour {

	Rigidbody2D phys;
	public Vector2 dir = Vector2.zero;
	public float speed = 0.0f;
	private Vector2 lastPos = Vector2.zero;
	private ActionQueue distanceCallbackQueue = new ActionQueue();
	Vector2 expectedVelocity = Vector2.zero;
	MotorComponent baseMotor;
	private float totalDistanceSquared = 0.0f;


	void Start () {
		phys = gameObject.GetComponent<Rigidbody2D> ();
		baseMotor = ScriptableObject.CreateInstance<MotorComponent> ();
		baseMotor.SetPhys (this.phys);
		lastPos = transform.position;
	}

	
	void FixedUpdate () {
		UpdatePhys (dir, speed);
	}

	void Clean() {
		this.distanceCallbackQueue.Clean();
	}

	public void SetDir(Vector2 pDir) {
		this.dir = pDir;
	}

	public void SetSpeed(float pSpeed) {
		speed = pSpeed;
	}

	public void AddDistanceCallback(PrioritizedAction pCallback) {
		distanceCallbackQueue.AddAction(pCallback); 
	}

	public void StopDistanceCallback(PrioritizedAction pCallback) {
		distanceCallbackQueue.RemoveAction (pCallback);
	}

	public float GetDistanceMoved() {
		return Mathf.Sqrt (totalDistanceSquared);
	}

	void UpdatePhys(Vector2 pDir, float pSpeed) {
		Vector2 actualVelocity = phys.velocity;
		/* semi-hack to add a force that gets properly cancelled out by the retro-thrusters in the motor(s) */
		if (actualVelocity != expectedVelocity) {
			Vector2 offsetVelocity = expectedVelocity - actualVelocity;
			phys.AddForce(offsetVelocity * phys.mass, ForceMode2D.Impulse);
		}

		baseMotor.ApplyNewVelocity (pDir * pSpeed);
		/* if we have more motors, we will sum and extract all of the velocities */
		expectedVelocity = baseMotor.currentVelocity;
		float dxSquared  = ((Vector2) transform.position - lastPos).magnitude;
		lastPos = transform.position;
		totalDistanceSquared += dxSquared;
		if (distanceCallbackQueue.Count () > 0) {
			distanceCallbackQueue.Execute ();
		}
	}
}
