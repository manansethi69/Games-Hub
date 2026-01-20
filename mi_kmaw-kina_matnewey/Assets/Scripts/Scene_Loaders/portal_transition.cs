using System.Runtime.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class portal_transition : MonoBehaviour
{

    private bool playerInPortal = false;
    private GameObject portal;
    private int sceneChangeTime = 0;
    public String portalDestination;
    public KeyCode interactKey = KeyCode.T;
    public GameObject portalPrompt;


    void Awake()
    {
        sceneChangeTime = PlayerPrefs.GetInt("PortalActive", 0);
        Debug.Log(sceneChangeTime);
        if(sceneChangeTime > 0)
        {
            PlayerPrefs.DeleteKey("PortalActive");
            Debug.Log("more than 1");
            portalPrompt.GetComponent<TextMeshProUGUI>().text = "You have already explored this void";
            portal.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // sceneChangeTime = PlayerPrefs.GetInt("SceneChangetime", 0);
        // if(sceneChangeTime > 0) {
        //     portal.SetActive(false);
        //     portalPrompt.GetComponent<Text>().text = "You have already explored this void";
        //     PlayerPrefs.DeleteKey("SceneChangetime");
        // }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInPortal = true;
            Debug.Log("in portal");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInPortal = false;
            Debug.Log("out of portal");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInPortal && Input.GetKeyDown(interactKey))
        {

            if (!string.IsNullOrEmpty(portalDestination))
            {
                sceneChangeTime += 1;
                PlayerPrefs.SetInt("SceneChangetime",sceneChangeTime);
                SceneManager.LoadScene(portalDestination);
            }
            else
            {
                Debug.LogError("Next Scene name is not assigned!");
            }
        }   
    }
}
