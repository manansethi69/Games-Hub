using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatLevelMusic : MonoBehaviour
{
    public AudioSource backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        PlayBackgroundMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    // Method to play the background music
    void PlayBackgroundMusic()
    {
        backgroundMusic.Play();
        
    }


}
