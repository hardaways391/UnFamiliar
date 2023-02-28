using UnityEngine;
using System.Collections;

public class PlayerMovement2 : MonoBehaviour
{
    // a fix to the weird character controller v1
    // minimal air control
    public CharacterController controller;
    private float verticalVelocity;
    private float groundedTimer;        // to allow jumping when going down ramps
    public float baseSpeed;
    private float speed;
    public float jumpHeight = 1.75f;
    private float gravity = 9.8f;
    public float pushForce = 2f;

    public bool movingLeft;
    public bool movingRight;
    public bool facingRight;

    private Animator animator;
    
    float xDirect;
    private float zLock;

    private void Start()
    {
        animator = GetComponent<Animator>();
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        bool groundedPlayer = controller.isGrounded;
        if (groundedPlayer)
        {
            groundedTimer = 0.2f; // small buffer to allow jumping on ramps (unlike v1)
        }
        if (groundedTimer > 0)
        {
            groundedTimer -= Time.deltaTime; // decrease unitl we're back at 0 and grounded again
        }

        // slam into the ground
        if (groundedPlayer && verticalVelocity < 0)
        {
            // hit ground
            verticalVelocity = 0f;
        }

        // constant gravity keeps us pulled down when going down ramps
        verticalVelocity -= gravity * Time.deltaTime;

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0); //move only left/right

        if(move.x < 0) //Flip so the animation plays in the correct direction
        {
            animator.SetBool("movingLeft", true);
            animator.SetBool("movingRight", false);
            Debug.Log("left");
        }
        else if(move.x > 0) //Flip so the animation plays in the correct direction
        {
            animator.SetBool("movingRight", true);
            animator.SetBool("movingLeft", false);
            Debug.Log("right");
        }
        else
        {
            animator.SetBool("movingRight", false);
            animator.SetBool("movingLeft", false);
        }
        move *= speed; // adjust speed in unity

        // allow jump as long as the player is on the ground
        if (Input.GetButtonDown("Jump"))
        {
            // must have been grounded recently to allow jump
            if (groundedTimer > 0)
            {
                // no more jumps until we land
                groundedTimer = 0;

                // Physics dynamics formula for calculating jump up velocity based on height and gravity
                verticalVelocity += Mathf.Sqrt(jumpHeight * 2 * gravity);
            }
        }

        move.y = verticalVelocity;

        if (transform.position.z != zLock)
        {
            move.z = (zLock - transform.position.z) * 25f;
        }
        controller.Move(move * Time.deltaTime); // always call at the end so everything else is already lined up properly

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 2.5f;
        }
        else
        {
            speed = baseSpeed;

            xDirect = Input.GetAxis("Horizontal") * speed;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic) //dont push a kinematic body
        {
            return;
        }
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, 0); //else, push it
        body.velocity = pushDir * pushForce;
    }
}