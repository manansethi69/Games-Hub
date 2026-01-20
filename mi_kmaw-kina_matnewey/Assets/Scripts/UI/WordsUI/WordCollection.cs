using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordCollection : MonoBehaviour
{
    //total amount of coins collected
    public static int totalWords = 0;
    public PlayerSoundSystem playerSoundSystem;
    public GameObject wordCoin;
    
    //variables for animation
    public GameObject wordAnim_Canvas;
    public AudioClip clip;
    public AudioSource source;

    public wordInformation wordInfo;
    public WordCollection wordScript;
    public Sprite wordImage;

    public string englishWord;
    public string mi_kmaw_Word;

    void Awake()
    {
        //resets the total amount of words to 0 when the scene is loaded
        totalWords = 0;

        playerSoundSystem = GameObject.Find("Player").GetComponent<PlayerSoundSystem>();

        wordAnim_Canvas = GameObject.Find("WordAnim_Canvas");

        wordInfo = GameObject.Find("WordAnimationPanel").GetComponent<wordInformation>();

    }

    void Start() {
        //counts how many words need to be collected, based off how many are implemented in the level
        totalWords++;
        wordAnim_Canvas.SetActive(false);
    }

    //if the word block collides with the player, it adds the word to a list, decrements the amount of words left to collect
    //and deactivates the word that was just collected
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            GetComponent<AddItemToInventory>().AddItem();
            totalWords--;
            wordAnim_Canvas.SetActive(true);
            wordCoin.GetComponent<Renderer>().enabled = false;
            wordInfo.startAnim();
            wordInfo.setSource(source);
            wordInfo.setClip(clip);
            wordInfo.setWordScript(wordScript);
            wordInfo.setEnglishWordText(englishWord);
            wordInfo.setMi_kmaw_WordText(mi_kmaw_Word);
            wordInfo.setWordImage(wordImage);
            playerSoundSystem.Hint();
        }
    }

    public void ExitWordCoinAnimation(){
        wordCoin.SetActive(false);
    }
}
