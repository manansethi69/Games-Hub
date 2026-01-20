using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingPage : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown musicDropdown;
    public AudioSource[] audioSources;

    public bool muteVolume;
    float volume = -10;

    void Start()
    {
        musicDropdown.ClearOptions();
        List<string> options = new List<string>();

        for(int i = 0; i < audioSources.Length; i++)
        {
            string option = audioSources[i].ToString();
            options.Add(option);
        }

        musicDropdown.AddOptions(options);
        audioSources[0].gameObject.SetActive(true);
    }

    public void SetVolume(float volume)
    {
        if (!muteVolume) 
        {
            audioMixer.SetFloat("volume", volume);
        }
        this.volume = volume;
    }

    public void SetMusic(int dropdownIndex)
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (i == dropdownIndex)
            {
                audioSources[i].gameObject.SetActive(true);
            }
            else
            {
                audioSources[i].gameObject.SetActive(false);
            }
        }
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetMute(bool mute)
    {
        if (mute) 
        {
            audioMixer.SetFloat("volume", -80);
            muteVolume = true;
        }
        else
        {
            muteVolume = false;
            SetVolume(volume);
        }
    }
}
