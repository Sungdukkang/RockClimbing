using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public Vector3 direction; 
	public float distance = 1f;
	public float speed = 1f;


	private Vector3 origin; 

	void Start() {
		origin = transform.position; 
	}

	void Update() {
		if (direction.x > 0) {
			transform.position = new Vector3 (origin.x - Mathf.PingPong (Time.time * speed, distance), origin.y, origin.z);
		} else if (direction.y > 0) {
			transform.position = new Vector3 (origin.x, origin.y - Mathf.PingPong (Time.time * speed, distance), origin.z);
		} else if (direction.z > 0) {
			transform.position = new Vector3 (origin.x, origin.y, origin.z - Mathf.PingPong (Time.time * speed, distance));
		} else {
			transform.position = origin;
		}

	}
}
