using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actualfootsteppers : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip footstep1;
    public AudioClip footstep2;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void PlaySoundEffect()
    {
        audioSource.PlayOneShot(footstep1, 0.7f); // play audio clip with volume 0.7
    }
    void PlaySoundEffect2()
    {
        audioSource.PlayOneShot(footstep2, 0.7f); // play audio clip with volume 0.7
    }
}