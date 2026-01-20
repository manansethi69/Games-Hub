using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class game_over_text_UI : MonoBehaviour
{

    public GameObject gameOverVisibilty;
    public TextMeshProUGUI gameOverText;
    public bool isGameOver = false;

    public void Start(){
        gameOverVisibilty.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        if (isGameOver == true)
        {
            //Debug.Log("its working until here");
            gameOverVisibilty.SetActive(true);
        }
    }

    public void dead(){
        isGameOver = true;
    }
}
