using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public Collider coll;
    private Rigidbody rb;
    public BoxCollider trigger;
    public Animator shrink = null;
    public Animator expand = null;

    // Start is called before the first frame update
    void Start()
    {
        coll= GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trigger.enabled = false;
            StartCoroutine(FallDown());
        }
    }
    public IEnumerator FallDown()
    {
        shrink.Play("platformShrink", 0, 0f);
        yield return new WaitForSeconds(1.75f);
        coll.enabled = false;
        yield return new WaitForSeconds(4.25f);
        shrink.Play("platformExpand", 0, 0f);
        coll.enabled = true;
        trigger.enabled = true;
    }
}
