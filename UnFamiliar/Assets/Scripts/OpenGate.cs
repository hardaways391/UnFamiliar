using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    [SerializeField] private Animator gate = null;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weight"))
        {
            gate.Play("OpenGate", 0, 0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Weight"))
        {
            gate.Play("CloseGate", 0, 0f);
        }
    }
}
