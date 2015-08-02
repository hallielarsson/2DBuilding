using UnityEngine;
using System.Collections;

public class MotorComponent : ScriptableObject {

	public Vector2 currentVelocity = new Vector2(0, 0);
	Rigidbody2D phys;

	public void SetPhys(Rigidbody2D pPhys) {
		if (pPhys != phys) {
			phys = pPhys;
		}
	}

	public Rigidbody2D GetPhys() {
		return phys;
	}

	public void ApplyNewVelocity(Vector2 pVelocity){
		if (phys != null) {
			float physMass = phys.mass;
			Vector2 deltaV = pVelocity - currentVelocity;
			phys.AddForce(deltaV * physMass);
		}
		currentVelocity = pVelocity;
	}

}
