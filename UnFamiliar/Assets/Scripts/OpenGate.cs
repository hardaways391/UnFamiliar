using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class OpenGate : MonoBehaviour
{
    [SerializeField] private Animator gate = null;
    CinemachineImpulseSource impulse;

    private void Start()
    {
        impulse = GetComponent<CinemachineImpulseSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weight") || other.CompareTag("Player"))
        {
            gate.Play("OpenGate", 0, 0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Weight") || other.CompareTag("Player"))
        {
            gate.Play("CloseGate", 0, 0f);
            Shake();
        }
    }

    void Shake()
    {
        impulse.GenerateImpulse();
    }
}
