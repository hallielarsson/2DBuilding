using UnityEngine;
using System.Collections;

public interface INodeOccupant {
	MapNodeScript node {get; set;}
	void OnAddToNode(MapNodeScript node);
	void OnRemoveFromNode(MapNodeScript node);
}
