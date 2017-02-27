using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Falling : MonoBehaviour
{
    public float fallingThreshold = 10f;
    public float maxFallingThreshold = 40f;
    private float initialDistance = 0f;
    public Transform player;
    public Transform spawnPoint;
    private RaycastHit hit;
    private GripManager gm;

    void Start()
    {
        var dist = 0f;
        GetHitDistance(out dist);
        initialDistance = dist;
        gm = GetComponent<GripManager>();
    }
    bool GetHitDistance(out float distance)
    {
        distance = 0f;
        Ray downRay = new Ray(transform.position, -Vector3.up); // this is the downward ray
        if (Physics.Raycast(downRay, out hit))
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Floor"))
            {
                distance = hit.distance;
                return true;
            }
        }
        return false;
    }
    void Update()
    {
        var dist = 0f;
        if (GetHitDistance(out dist))
        {
            if (initialDistance < dist)
            {
                //Get relative distance
                var relDistance = dist - initialDistance;
                //Are we actually falling?
                if (relDistance > fallingThreshold)
                {
                    //How far are we falling
                    if (relDistance > maxFallingThreshold) {
                        player.position = spawnPoint.position;
                    }
                    else Debug.Log("basic falling!");
                }
            }
        }
        else
        {
           
        }
    }
}
