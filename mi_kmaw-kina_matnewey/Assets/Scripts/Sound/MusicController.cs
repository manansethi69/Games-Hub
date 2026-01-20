using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    // Audios
    public AudioSource backgroundMusic;
    public AudioSource bossMusic;

    // Start is called before the first frame update
    void Start()
    {
        // Play the background music at the start
        PlayBackgroundMusic();
    }

    // Method to play the background music
    void PlayBackgroundMusic()
    {
        backgroundMusic.Play();
        bossMusic.Stop();
    }

    // Method to play the boss music
    void PlayBossMusic()
    {
        backgroundMusic.Stop();
        bossMusic.Play();
    }

    // Method to handle boss fight start
    public void StartBossFight()
    {
        PlayBossMusic();
    }

    // Method to handle boss fight end
    public void EndBossFight()
    {
        PlayBackgroundMusic();
    }
}