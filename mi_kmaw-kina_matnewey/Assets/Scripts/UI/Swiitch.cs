using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Swiitch : MonoBehaviour
{
    public Image cardSprite;
    public GameObject[] background;
    int index;
    public Sprite[] sprites; 
    public Text text;
    public string[] words;
    public AudioSource source;
    public AudioClip clip;
    public AudioClip[] clips;

    void Start()
    {
        index = 0;
    }

    public void Next()
    {
        source.PlayOneShot(clips[index]);
        if (index < sprites.Length - 1){
        index += 1;
        cardSprite.sprite = sprites[index];
        }
        else{
            index = 0;
            cardSprite.sprite = sprites[index];
        }
       
        
    }

    public void Previous()
    { 
        index -= 2;
        if (index > -1){
        source.PlayOneShot(clips[index]);
        index++;
        cardSprite.sprite = sprites[index];
        }
        else{
            index = 6;
            source.PlayOneShot(clips[index]);
            index = 0;
            cardSprite.sprite = sprites[index];
        }
        
    }


}