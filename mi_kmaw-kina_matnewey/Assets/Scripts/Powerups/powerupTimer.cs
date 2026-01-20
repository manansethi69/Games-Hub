// this code is orignally taken from Maguire's code

using System.Collections;
using System.Collections.Generic;
//using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;


//Set a time limit for how long you can remain in a scene, originally built for level5_house bonus level
public class powerupTimer : MonoBehaviour
{
    public float currentTime;
    public Text timerDisplay;

    // Update is called once per frame
    public void startTimer(int i)
    {
        gameObject.SetActive(true);
        currentTime = i;
    }

    public void Update(){
        //subtract time, and display with 2 decimal places
        currentTime -= Time.deltaTime;
        timerDisplay.text = currentTime.ToString("0.00");

        if(currentTime < 0){
            gameObject.SetActive(false);
        }
    }
}
