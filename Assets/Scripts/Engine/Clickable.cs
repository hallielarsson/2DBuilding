using UnityEngine;
using System.Collections;

public class Clickable : MonoBehaviour {


	public Collider2D shape;
	
	public Vector3 mousePos = Vector3.zero;
	// Use this for initialization
	void Start () {
		shape = GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	/*
	void Update () {
		mousePos = Input.mousePosition;
		if(Input.GetMouseButtonDown(0)) {
			this.OnClick(mousePos);
		}	
	}
	*/
	public void OnClick(Vector2 mousePos) {
		//GameObject.Find ("GameLoader").GetComponent<GameLoadScript> ().StartLoadGame ();
	}
}
