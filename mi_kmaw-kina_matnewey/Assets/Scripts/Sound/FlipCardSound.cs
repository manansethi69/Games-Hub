using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCardSound : MonoBehaviour
{
    public AudioSource audioSource;
    public void playFlipCardSound()
    {
        if (audioSource == null)
        {
            Debug.Log("Haven't add any audio yet");
        }
        else
        {
            audioSource.Play();
        }
    } 
}
