using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripManager : MonoBehaviour {

	public Rigidbody Body;

	public Pull left;
	public Pull right;

	public float velocityMultiplier = 1.5f;
    public bool isGripped;
    public bool startedClimbing;
    public bool canFall;
    public float fallThreshold = 0f;

	// Use this for initialization
	void Start () {
        isGripped = false;
        canFall = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		var lDevice = SteamVR_Controller.Input ((int)left.controller.index);
		var rDevice = SteamVR_Controller.Input ((int)right.controller.index);

	    isGripped = left.canGrip || right.canGrip;

        if (isGripped)
        {
            startedClimbing = true;



            if (Body.transform.position.y > fallThreshold)
            {
                canFall = true;
            }

            if (left.canGrip && lDevice.GetPress(SteamVR_Controller.ButtonMask.Trigger)) {
                Body.useGravity = false;
                Body.isKinematic = true;
                Body.transform.position += (left.prevPos - left.transform.localPosition);
            }

            else if (left.canGrip && lDevice.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                Body.useGravity = true;
                Body.isKinematic = false;
                Body.velocity = ((left.prevPos - left.transform.localPosition) * velocityMultiplier) / Time.deltaTime;
            }

            if (right.canGrip && rDevice.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            {
                Body.useGravity = false;
                Body.isKinematic = true;
                Body.transform.position += (right.prevPos - right.transform.localPosition);
            }
            else if (right.canGrip && rDevice.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                Body.useGravity = true;
                Body.isKinematic = false;
                Body.velocity = ((right.prevPos - right.transform.localPosition) * velocityMultiplier) / Time.deltaTime;
            }

        } else 
		{
			Body.useGravity = true;
			Body.isKinematic = false;
        }

        left.prevPos = left.transform.localPosition;
		right.prevPos = right.transform.localPosition;
	}
}

