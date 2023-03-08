using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public PlayerMovement2 playerMovement2;
    public float springJumpHeight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            playerMovement2.verticalVelocity += springJumpHeight;
        }
    }
}
