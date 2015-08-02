using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeManager : MonoBehaviour {

	public List<MapNodeScript> nodes = new List<MapNodeScript>();
	public Dictionary<MapNodeScript, bool> nodeSet = new Dictionary<MapNodeScript, bool>();
	public MapNodeScript topLeftNode;
	public MapNodeScript bottomRightNode;

	// Use this for initialization
	void Start () {
		MakeGrid (topLeftNode, bottomRightNode, 10, 10);
		nodes.AddRange (GetComponentsInChildren<MapNodeScript> ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public MapNodeScript GetClosestNode(Vector2 pos) {
		MapNodeScript outNode = null;
		float minDistSquared = Mathf.Infinity;
		nodes.ForEach (delegate(MapNodeScript node) {
			if(!node.IsOccupied()) {
				Vector2 delta = (Vector2) node.transform.position - pos;
				float dSquared = delta.sqrMagnitude;
				if(dSquared < minDistSquared) {
					outNode = node;
					minDistSquared = dSquared;
				}
			}
		});
		return outNode;
	}

	public void MakeGrid(MapNodeScript topLeftNode, MapNodeScript bottomRightNode, int cols, int rows) {
		Transform parent = transform;
		Vector3 topLeft = topLeftNode.transform.position;
		Vector3 bottomRight = bottomRightNode.transform.position;
		Vector3 delta = bottomRight - topLeft;
		float deltaX = 0f;
		float deltaY = 0f;

		for (float i = 0; i < cols; i++) {
			deltaX =  i/(cols - 1);
			for(float j = 0; j < rows; j++) {
				deltaY = j/(rows - 1);
				Vector3 newPos = topLeft + new Vector3(delta.x * deltaX, delta.y * deltaY,delta.z * deltaX);
				MapNodeScript nodeScript;
				if(deltaX == 0 && deltaY == 0){ 
					nodeScript = topLeftNode;
				} else if (deltaX == 1 && deltaY == 1) {
					nodeScript = bottomRightNode;
				} else {
					GameObject node = GameObject.Instantiate<GameObject>(topLeftNode.gameObject);
					node.transform.position = newPos;
					node.transform.SetParent(parent);
					nodeScript = node.GetComponent<MapNodeScript>();
				}
			}
		}
	}
}
