using UnityEngine;
using System.Collections;

public class Utils : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void Assert(bool pAssertion, string pAssertMessage = "Assertion failed") {
		if (!pAssertion) {
			throw new UnityException(pAssertMessage);
		}
	}

	public static void trace(string message) {
		print (message);
	}
}
