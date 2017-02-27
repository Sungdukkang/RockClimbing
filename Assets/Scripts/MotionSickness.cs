using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class MotionSickness : MonoBehaviour {

	public Rigidbody player;
	public VignetteAndChromaticAberration v;

	public const float MAXSPEED = 8f;
	public const float MAXLIMIT = 0.6f;

	// Update is called once per frame
	void Update () {
		float scale = player.velocity.magnitude / MAXSPEED * MAXLIMIT;
		if (player.velocity.magnitude > MAXSPEED) 
		{
			scale = MAXLIMIT;
		}

		v.intensity = scale;
		//v.intensity = Mathf.Lerp(0f, scale, Time.deltaTime);
	}
}
