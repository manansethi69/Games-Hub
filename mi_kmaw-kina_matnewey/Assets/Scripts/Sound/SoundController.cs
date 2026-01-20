using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControler : MonoBehaviour
{
    //Audios
    public AudioSource audioSourceOnce;
    public AudioSource audioSourceLoop;
    // Start is called before the first frame update
    void Start()
    {
        //sound effect volume preference
        if (audioSourceOnce != null)
        {
            audioSourceOnce.volume = PlayerPrefs.GetFloat("SoundEffectVolume", 1.0f);
        }
        if (audioSourceLoop != null)
        {
            audioSourceLoop.volume = PlayerPrefs.GetFloat("SoundEffectVolume", 1.0f);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSourceOnce.loop = false;
        audioSourceOnce.PlayOneShot(clip);
    }
    public void PlaySoundLoop(AudioClip clip)
    {
        audioSourceLoop.loop = transform;
        audioSourceLoop.clip = clip;
        audioSourceLoop.Play();
    }
    public void StopLoopSound()
    {
        audioSourceLoop.Stop();
    }
}
