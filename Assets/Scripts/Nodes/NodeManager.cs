using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeManager : MonoBehaviour {

	public List<MapNodeScript> nodes = new List<MapNodeScript>();
	public Dictionary<MapNodeScript, bool> nodeSet = new Dictionary<MapNodeScript, bool>();
	// Use this for initialization
	void Start () {
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
}
