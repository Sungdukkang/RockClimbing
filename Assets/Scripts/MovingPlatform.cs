using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public Vector3 direction; 
	public float distance = 1f;
	public float speed = 1f;

    public Rigidbody Body;
 
    private Vector3 origin; 

	void Start() {
		origin = transform.position;
	}

	void Update() {
        float movement = Mathf.PingPong(Time.time * speed, distance);
        if (direction.x > 0) {
            transform.position = new Vector3 (origin.x - movement, origin.y, origin.z);
          
        } else if (direction.y > 0) {
			transform.position = new Vector3 (origin.x, origin.y - movement, origin.z);
           
        } else if (direction.z > 0) {
			transform.position = new Vector3 (origin.x, origin.y, origin.z - movement);
      
        } else {
			transform.position = origin;
		}
        

    }

}
