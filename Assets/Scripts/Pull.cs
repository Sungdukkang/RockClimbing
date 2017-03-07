using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull : MonoBehaviour {

	public SteamVR_TrackedObject controller;

	[HideInInspector]
	public Vector3 prevPos;

	[HideInInspector]
	public bool canGrip;

	// Use this for initialization
	void Start () 
	{
		prevPos = controller.transform.localPosition;
	}

	void OnTriggerEnter(Collider other) 
	{
        if (other.gameObject.layer == LayerMask.NameToLayer("Grip")) {
            canGrip = true;
        }	
	}

	void OnTriggerExit()
	{
		canGrip = false;
	}
}
