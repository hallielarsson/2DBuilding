using UnityEngine;
using System.Collections;

public class MapObject : MonoBehaviour, INodeOccupant  {

	public MapNodeScript node {get; set;}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnAddToNode(MapNodeScript pNode){
		this.node = pNode;
		pNode.SetOccupant (this);
	}
	public void OnRemoveFromNode(MapNodeScript pNode){
		pNode.RemoveOccupant (this);
		node = null;
	}
}
