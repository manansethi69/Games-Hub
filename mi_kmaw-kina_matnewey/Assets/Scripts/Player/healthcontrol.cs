using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class healthcontrol : MonoBehaviour
{
    public int playerHealth = 3;
    public int heartCount = 0;
    
    public GameObject character;
    private GameObject heart;
    private Transform canvas;
    [SerializeField] public List<Image> hearts;
    private game_over_text_UI gameOver;

    private void Awake()
    {

        canvas = GameObject.Find("Canvas").GetComponent<Transform>();

        if (canvas == null)
        {
            Debug.LogError("UI Canvas Not Found!!!");
        }

        GameObject heartObject = GameObject.Find("heart1");
        Transform heartTransform = heartObject.transform;
        
        if (heartTransform == null)
        {
            Debug.LogError("Heart UI Not Found!!!");
        }
        else
        {
            heart = heartTransform.gameObject;
        }
        
        gameOver = GameObject.Find("GameOverMessage").GetComponent<game_over_text_UI>();

        if (gameOver == null)
        {
            Debug.LogError("Game Over Message Not Found!!!");
        }
        
    }

    private void Start()
    {
        // sets the player health. Default is 5 is nothing is set.
        playerHealth = PlayerPrefs.GetInt("playerHealth",5); // 5 as default just in case 
        addhealth();
        UpdateHealth();
    }

    public void addhealth() {
        // Only add new hearts if playerHealth exceeds current heart count
        while (heartCount < playerHealth) {
            // Instantiates a new heart
            GameObject newHeart = Instantiate(heart, new Vector2(heart.transform.position.x + (55 * heartCount), heart.transform.position.y), heart.transform.rotation);
            newHeart.transform.SetParent(canvas);
            newHeart.transform.localScale = heart.transform.localScale;
            newHeart.SetActive(true);

            hearts.Add(newHeart.GetComponent<Image>());
            heartCount++;
        }
        UpdateHealth(); // Update health UI after adding new hearts
    }

        
    public int getHealth() {
        return playerHealth;
    }

    public int getMaxHealth() {
        return heartCount;
    }


    public void UpdateHealth()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            //Debug.Log("health decreased");
            if(i < playerHealth)
            {
                hearts[i].color = Color.white;
            }
            else
            {
                hearts[i].color = Color.black;
            }
        }
    }

    public void updateHealthUI(int healthToAdd) {
        playerHealth += healthToAdd;
        addhealth();
        UpdateHealth();
    }

    public void death(){
        if (playerHealth<=0){
            Debug.Log("YOURE DEAD");

            //gameOver.isGameOver = true;
            gameOver.dead();
            character.SetActive(false);


        }
    }

    public void levelChange(string level) {
        if (playerHealth<=0){
            SceneManager.LoadScene(level);
        }
    }

    // transition to other scene
    public void spawnDelay(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void mainMenu(){
        SceneManager.LoadScene("Homepage");
    }
    public void levelSelect(){
        SceneManager.LoadScene("StartScene");
    }

    public void updateHealth(int addHealth){
        playerHealth += addHealth;
    }

}
