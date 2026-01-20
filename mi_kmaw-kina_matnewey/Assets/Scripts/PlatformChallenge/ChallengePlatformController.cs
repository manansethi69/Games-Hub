using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChallengePlatformController : MonoBehaviour
{

    private ChallengePlatform[] platforms;
    public string correctWord;
    public string sceneAfterDone;
    [System.Serializable]
    public class wordImages{
        public string word;
        public Sprite image;
    }
    public wordImages[] words;

    [SerializeField]
    private Text HintText;
    [SerializeField]
    public int count;

    public bool justDisplayHint;


    // Start is called before the first frame update
    void Start()
    {
        sceneAfterDone = GameObject.Find("Platforms").GetComponent<levelInfo>().levelName;
        if(!justDisplayHint)
        {
            platforms = GetComponentsInChildren<ChallengePlatform>();
            assignWordsToPlatforms();
        }
    }

    //Randomly chooses a platform to have the correct word, and gives all platforms an assigned word
    private void assignWordsToPlatforms()
    {
        //randomly pick an index for which platform will be the correct one, always round the float down
        int correctIndex = Mathf.FloorToInt(Random.Range(0, platforms.Length));

        //Error case
        if(words.Length < platforms.Length)
        {
            throw new System.Exception("Not enough Incorrect Words given to Challenge Platform Controller, make sure to have at least as many words as there are platforms");
        }

        //Go through all platforms, assign each a word, give correct word to platform at randomly chosen index
        //It also assigns the corresponding images for the word
        for(int i=0; i < platforms.Length; i++)
        {
            if (i == correctIndex)
            {
                platforms[i].assignedWord = words[i].word;
                platforms[i].assignedImage = words[i].image;
                platforms[i].isCorrect = true;
                correctWord = words[i].word;
                platforms[i].count = count;
                
            }
            else
            {
                platforms[i].assignedWord = words[i].word;
                platforms[i].assignedImage = words[i].image;
                platforms[i].isCorrect = false;
            }
        }
    }

    //Each layer has a collision box placed underneath it, when entered by the player, display the hint for the platforms
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            HintText.text = correctWord;

            //trigger when level is done and then player is sent back to level
            if(HintText.text.Equals("Done!")) {
                SceneManager.LoadScene(sceneAfterDone);
            }
        }
    }

   
}
