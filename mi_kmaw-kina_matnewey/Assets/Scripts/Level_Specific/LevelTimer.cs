using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Set a time limit for how long you can remain in a scene, originally built for level5_house bonus level
public class LevelTimer : MonoBehaviour
{
    public float maxTime;
    private float currentTime;
    public Text timerDisplay;
    public string targetScene;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        //subtract time, and display with 2 decimal places
        currentTime -= Time.deltaTime;
        timerDisplay.text = currentTime.ToString("0.00");

        //When time reaches 0, load previous scene (prev scene must be manually set)
        if(currentTime < 0)
        {
            SceneManager.LoadScene(targetScene);
        }
    }
}
