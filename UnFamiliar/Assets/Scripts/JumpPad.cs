using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public PlayerMovement2 playerMovement2; //reference the player movement script
    public float springJumpHeight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            playerMovement2.verticalVelocity += springJumpHeight; // increase the player's y position in the movement script by the value we set in unity
        }
    }
}
