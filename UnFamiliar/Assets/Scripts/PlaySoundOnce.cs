using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnce : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            source.clip = clip;
            source.Play();
        }
    }
}
