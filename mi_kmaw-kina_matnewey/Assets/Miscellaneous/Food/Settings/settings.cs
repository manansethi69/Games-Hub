using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class settings : MonoBehaviour
{
    public GameObject Settings;

    // This method resumes the game when clicked
    public void resume(){
        Settings.SetActive(false);
    }

    // This method returns the user to the homepage
    public void exit(){
        SceneManager.LoadScene("Homepage");
    }

    // This method loads the start scene (where you can select your levels)
    public void ChapterSelect(){
        SceneManager.LoadScene("StartScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        // sets the settings ui to not display
        Settings.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

        // when the user presses escape, the settings ui is not displayed
        // alternatively, the settings is shown when you press escape, but that code is PlayerMovements.cs
        if(Input.GetKeyDown(KeyCode.Escape)){
            Settings.SetActive(false);
        }
    }
}
