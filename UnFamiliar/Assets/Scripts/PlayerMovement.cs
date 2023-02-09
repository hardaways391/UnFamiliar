using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public CharacterController controller;
    public float jumpStrength;
    public float gravityScale;

    public float pushForce = 1f;

    private Vector3 moveDirection;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, 0f);

        if (controller.isGrounded)
        {
            moveDirection.y = -1f;
            if (Input.GetButtonDown("Jump")) //full strength jump
            {
                moveDirection.y = jumpStrength;
            }
        }
        else
        {
            moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale); //gravity we can set in inspector
        }

        if (Input.GetButtonUp("Jump") && moveDirection.y > 0) //lil baby jump
        {
            moveDirection.y = (jumpStrength * 0.35f);
        }

        controller.Move(moveDirection * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic)
        {
            return;
        }
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, 0);
        body.velocity = pushDir * pushForce;
    }
}