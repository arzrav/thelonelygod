using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	float speed = 500;

	void Update () {
		Vector3 input = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
		Vector3 direction = input.normalized;
		Vector3 velocity = direction * speed;
		Vector3 moveAmount = velocity * Time.deltaTime;

		if (Input.mouseScrollDelta.y == -1) {
			if ((transform.position + moveAmount + new Vector3 (0, 200, 0)).y <= 2000) {
				moveAmount += new Vector3 (0, 200, 0);
			}
		} else if (Input.mouseScrollDelta.y == 1) {
			if ((transform.position + moveAmount + new Vector3 (0, -200, 0)).y >= 400) {
				moveAmount += new Vector3 (0, -200, 0);
			}
		}
			
		transform.position += moveAmount;
	}
}
