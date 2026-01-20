using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public void Homepage()
    {
        SceneManager.LoadScene("Homepage");
    }

    public void StartGame()
    {
        // Loads into the level difficulty selection screen
        SceneManager.LoadScene("LevelDifficulty"); // Loads into the level difficulty selection screen

        //SceneManager.LoadScene("StartScene");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Practice");
    }

    public void Settings()
    {
        SceneManager.LoadScene("SettingsScence");
    }
    public void Credit()
    {
        SceneManager.LoadScene("CreditPage");
    }
    public void Quit()
    {
        Application.Quit();
    }

/**
    Sets the game game difficulty to easy mode, by setting the player health to 5 */
    
    public void Easy(){
        PlayerPrefs.SetInt("playerHealth",5); 
        SceneManager.LoadScene("StartScene"); // load to StartScene
    }


    /**
    Sets the game difficulty to hard mode, by setting the player health to 3 */
    
    public void Hard(){
        PlayerPrefs.SetInt("playerHealth",3);
        SceneManager.LoadScene("StartScene"); // load to StartScene

    }

}


