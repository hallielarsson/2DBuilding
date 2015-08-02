using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	public BuildingController controller;

	// Use this for initialization
	public void Start () {
		controller = gameObject.GetComponent<BuildingController> ();
	}
	
	// Update is called once per frame
	void Update () {
		SetMoveDirFromAxes ();
	}


	/* for keyboard etc. control if we ever want it */
	public void SetMoveDirFromAxes() {
		Vector2 moveDir = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		controller.Move (moveDir);

	}
}
