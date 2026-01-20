using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelTransition : MonoBehaviour
{

    public Boolean isFinalLevel = false;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            String scene = SceneManager.GetActiveScene().name;
            switch (scene)
            {
                case "TutorialLevel":
                    SceneManager.LoadScene("Main");
                    break;
                case "Main":
                    SceneManager.LoadScene("Level2");
                    break;
                case "Level2":
                    SceneManager.LoadScene("Level3");
                    break;
                case "Level3":
                    SceneManager.LoadScene("endScreen");
                    break;
                case "Level4":
                    SceneManager.LoadScene("Level5");
                    break;
                case "Level5":
                    SceneManager.LoadScene("Level6");
                    break;
            }
            
            if(isFinalLevel) {
                SceneManager.LoadScene("endScreen");
            }
        
        }
    }
}
 