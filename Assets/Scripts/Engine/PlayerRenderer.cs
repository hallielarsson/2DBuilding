using UnityEngine;
using System.Collections;

public class PlayerRenderer : MonoBehaviour {

	GameObject view;
	static Vector3 zAxis = new Vector3(0, 0, 1);
	void Start () {
		view = transform.Find ("View").gameObject;
	}

	public void SetDir (Vector2 pDir) {
		Quaternion newRotation = Quaternion.AngleAxis (Mathf.Atan2(pDir.y, pDir.x) * 180 / Mathf.PI, zAxis);
		view.transform.rotation = newRotation;
	}
}
