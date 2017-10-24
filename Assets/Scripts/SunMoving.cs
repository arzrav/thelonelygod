using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMoving : MonoBehaviour {

	float x0 = 0;
	float y0 = 0;
	float radiusCircle = 1250;
	float angle = 0;

	void Start() {
		InvokeRepeating ("ChangeSunPosition", 0.0f, 0.05f);
	}

	void ChangeSunPosition () {
		Vector3 newSunPosition = new Vector3 (x0 + radiusCircle * Mathf.Cos (angle), y0 + radiusCircle * Mathf.Sin (angle), 0);
		transform.position = newSunPosition;
		angle += Mathf.PI / 3600;
	}
}
