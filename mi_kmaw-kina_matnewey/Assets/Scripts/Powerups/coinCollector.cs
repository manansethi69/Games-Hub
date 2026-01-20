using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//random guy in comments of collect and count items video from coding in flow thanks bro
using TMPro;

public class coinCollector : MonoBehaviour
{
    //the int for score
    public int score = 0;
    private healthcontrol healthControl;
    private int startingScore = 0;

    private void Awake()
    {
        healthControl = gameObject.GetComponent<healthcontrol>();
    }

    //the method to assign the other collision
    //public enemyCollision playerCollision;
    
    //video coin collecting and unity api coding thing
    //collect and count items coding in flow also random guy
    //this is for the UI is assigns it the text on the canvas object
    //[SerializeField] private TextMeshProUGUI scoreUI;
    GameObject scoreUI;
    //private method for when it triggers collider collision
    private void OnTriggerEnter2D(Collider2D collision){
        //if what is colliding has the tag coins
        if(collision.gameObject.CompareTag("Coins"))
        {
            //destroy the object
            Destroy(collision.gameObject);
            // add 1 to score
            changeScore(1);
            //the text called scoreUI text method is being changed to Coins then the score then health then the lives they have
            //scoreUI.text = "Points: " + score;
            updateScoreUI();
        }else if (collision.gameObject.CompareTag("Treasure"))
        {
            //destroy the object
            Destroy(collision.gameObject);
            // add 1 to score
            changeScore(3);
            //the text called scoreUI text method is being changed to Coins then the score then health then the lives they have
            //scoreUI.text = "Points: " + score;
            updateScoreUI();
        }
    }
    //update the score UI scoreUI.text = the text on the canvas
    public void updateScoreUI(){
        if (MainManager.Instance != null) { score = MainManager.Instance.coinInventory; }
        scoreUI.GetComponent<TMPro.TextMeshProUGUI>().text = "Points: " + score.ToString();
    }
    
    //method to change the score
    //if you wanna decrease score add a -1 x
    public void changeScore(int x){
        Scene currentScene = SceneManager.GetActiveScene();
        score += x;
        //coinNumber = score;
        if (score < 0)
        {
            score = 0;
        }

        if (MainManager.Instance != null)
        {
            MainManager.Instance.coinInventory = score;
        }
        
        //if current scene is Level5_House, then store coin number to PlayerPrefs.
        if(currentScene.name == "Level5_House")
        {
            //PlayerPrefs.SetInt("coinNumber", coinNumber);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreUI = GameObject.Find("PointsUI");

        if(MainManager.Instance != null)
        {
            startingScore = MainManager.Instance.coinInventory;
        }

        score = startingScore;
    }

    // Update is called once per frame
    void Update()
    {
        //constantly update UI
        updateScoreUI();

    }

    //When player dies, reset coins to what they were at the start of the level.
    void OnDestroy()
    {
        if(healthControl.playerHealth <= 0)
        {
            if (MainManager.Instance != null) {
                MainManager.Instance.coinInventory = startingScore;
            }
        }
    }
}
