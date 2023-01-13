using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    private AudioSource audioSource;

    //Store audio source 
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //Play audio source, if available
    private void OnCollisionEnter(Collision collision)
    {
        audioSource?.Play();
    }
}
