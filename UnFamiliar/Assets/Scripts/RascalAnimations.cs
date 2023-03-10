using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RascalAnimations : MonoBehaviour
{
    //public bool running = false;
    //public bool walking = false;
    //public bool right;

    public PlayerMovement2 pm2;
    public Animator rascalAnimator;

    private void Start()
    {
        rascalAnimator= GetComponent<Animator>();

        rascalAnimator.SetBool("walking", false);
        rascalAnimator.SetBool("running", false);
    }
    public void Update()
    {
        WalkCheck();
        RunCheck();
    }

    public void WalkCheck()
    {
        if (pm2.move.x > 0)
        {
            rascalAnimator.SetBool("walking", true);
            rascalAnimator.SetBool("right", true);
        }
        else if (pm2.move.x < 0)
        {
            rascalAnimator.SetBool("walking", true);
            rascalAnimator.SetBool("right", false);
        }
        else if (pm2.move.x == 0)
        {
            rascalAnimator.SetBool("walking", false);
            rascalAnimator.SetBool("running", false);
        }
    }

    public void RunCheck()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rascalAnimator.SetBool("running", true);
            rascalAnimator.SetBool("walking", false);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            rascalAnimator.SetBool("running", false);
        }
    }

    public void TurnCheck()
    {
        
    }
    
}
