using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapNodeScript : MonoBehaviour {

	public List<MapNodeScript> nodes = new List<MapNodeScript>();
	public INodeOccupant occupant;
	// Use this for initialization
	void OnDrawGizmos() {
		Gizmos.color = new Color (0.0f, 0.0f, 1.0f, 0.8f);
		Gizmos.DrawSphere(transform.position, 0.2f);
		foreach (MapNodeScript node in nodes) {
			Gizmos.color = new Color (0.0f, 0.0f, 1.0f, 0.8f);
			Vector3 delta = node.transform.position - transform.position;
			Gizmos.DrawLine(transform.position, node.transform.position);
			Gizmos.color = new Color (1.0f, 0.0f, 1.0f, 0.8f);
			Gizmos.DrawSphere(transform.position + delta * 0.9f, 0.1f);
		}
	}

	public bool IsOccupied() {
		return occupant != null;
	}
	public void SetOccupant(INodeOccupant pOccupant) {
		occupant = pOccupant;
	}	
	public void RemoveOccupant(INodeOccupant pOccupant) {
		occupant = null;
	}
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
