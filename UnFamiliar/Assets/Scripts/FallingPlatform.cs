using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public Collider coll;
    private Rigidbody rb;
    public BoxCollider trigger; // only fall down if we land on top
    public Animator shrink = null;
    public Animator expand = null;

    // Start is called before the first frame update
    void Start()
    {
        coll= GetComponent<Collider>();

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trigger.enabled = false; //turn off trigger so animation only plays once
            StartCoroutine(FallDown());
        }
    }
    public IEnumerator FallDown()
    {
        shrink.Play("platformShrink", 0, 0f); //start the shaking and falling animation
        yield return new WaitForSeconds(1.75f);
        coll.enabled = false; //no more floor to stand on
        yield return new WaitForSeconds(4.25f);
        shrink.Play("platformExpand", 0, 0f); //regrow the platform and turn collision back on
        yield return new WaitForSeconds(.5f);
        coll.enabled = true;
        trigger.enabled = true;
    }
}
