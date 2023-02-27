using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogFollow : MonoBehaviour
{
    public GameObject fog; 
    public GameObject target; // What you want to follow
    public float depthOffset; //push the fog back

    private Vector3 fogPos; // Variable that contains the Cameras x,y,z position

    void Start()
    {
        fog = this.gameObject;
        fogPos = target.transform.position; // stores the Camera's position in the variable
    }

    // Update is called once per frame
    void Update()
    {
        fogPos.z = target.transform.position.y + depthOffset;
        fogPos.x = target.transform.position.x; // Change The X position of fog to be the same as the target X position
        fog.transform.position = fogPos; // Moves the fog to the new position
    }
}
