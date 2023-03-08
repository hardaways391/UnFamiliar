using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeowButton : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] meow;
    private AudioClip meowClip;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int index = Random.Range(0, meow.Length);
            meowClip = meow[index];
            audioSource.clip = meowClip;
            audioSource.Play();
        }
    }
}
