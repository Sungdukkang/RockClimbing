using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGround : MonoBehaviour {

    public GameObject player;
    public float fallThreshold = 5f; 
    private GripManager gm;

    void OnCollisionEnter(Collision other) {
        GripManager gm = player.GetComponent<GripManager>() as GripManager;

        if (gm.startedClimbing && gm.canFall)
            {
                Debug.Log("hit the ground");
                gm.startedClimbing = false;
                gm.canFall = false;
            }
        }
}
