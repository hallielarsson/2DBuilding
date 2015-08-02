using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingManager : MonoBehaviour {

	public List<BuildingController> buildings = new List<BuildingController>();
	// Use this for initialization

	void Start () {
		PopulateBuildings ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void PopulateBuildings() {
		buildings.AddRange(gameObject.GetComponentsInChildren<BuildingController> ());
	}
}
