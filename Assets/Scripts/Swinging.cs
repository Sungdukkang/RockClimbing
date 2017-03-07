using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swinging : MonoBehaviour {

	public Rigidbody player;

	public SteamVR_TrackedObject controller;
	public LineRenderer line;
	public float force = 20f;
	public float distance = 1000f;
    public Transform pointer;

    public LayerMask layerMask;
	private Vector3 target;

	void FixedUpdate () {
		var device = SteamVR_Controller.Input ((int)controller.index);
		if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
			RaycastHit hit;
            /*
            if (Physics.Raycast (controller.transform.position, controller.transform.forward, out hit, distance, layerMask)) {
				line.enabled = true;
				line.SetPosition (0, controller.transform.position); // need to use the gun muzzle position

				target = hit.point;
				line.SetPosition (1, target);

				player.AddForce ((target - controller.transform.position).normalized * force);

				line.material.mainTextureOffset = Vector2.zero;
			}
		} else if (device.GetTouch (SteamVR_Controller.ButtonMask.Grip) && line.enabled) {
			line.SetPosition (0, controller.transform.position);
			line.material.mainTextureOffset = new Vector2 (line.material.mainTextureOffset.x + Random.Range(-0.1f, 0.5f), 0f);

			player.AddForce((target - controller.transform.position).normalized * force);
		} else 
		{
			line.enabled = false;
		}
        */

        if (Physics.Raycast(pointer.position, pointer.forward, out hit, distance, layerMask))
            {
                line.enabled = true;
                line.SetPosition(0, pointer.position); // need to use the gun muzzle position

                target = hit.point;
                line.SetPosition(1, target);

                player.AddForce((target - pointer.position).normalized * force);

                line.material.mainTextureOffset = Vector2.zero;
            }
        }
        else if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger) && line.enabled)
        {
            line.SetPosition(0, pointer.position);
            line.material.mainTextureOffset = new Vector2(line.material.mainTextureOffset.x + Random.Range(-0.1f, 0.5f), 0f);

            player.AddForce((target - pointer.position).normalized * force);
        }
        else
        {
            line.enabled = false;
        }

    }
}
