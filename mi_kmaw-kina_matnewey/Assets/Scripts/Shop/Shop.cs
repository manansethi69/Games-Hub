using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Shop : MonoBehaviour
{
    private bool playerInRange;
    private bool shopOpen;
    public KeyCode interactKey = KeyCode.T;
    private GameObject shopUI;

    private Animator playerAnimator;
    
    void Awake()
    {
        playerInRange = false;
        shopOpen = false;
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();

        shopUI = GameObject.Find("ShopUI");
        
        if (shopUI == null)
        {
            Debug.LogError("Shop UI Not Found!!!");
        }
        else
        {
            shopUI.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //Toggle UI if player is close enough and pressed the key
        if (playerInRange && Input.GetKeyDown(interactKey)) {
            if (shopOpen)
            {
                CloseShopUI();
            } else
            {
                OpenShopUI();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

    public void OpenShopUI()
    {
        shopUI.SetActive(true);
        
        if (!shopUI.activeSelf)
        {
            shopUI.SetActive(true);
        }
        
        playerAnimator.enabled = false;
        Time.timeScale = 0f;
        shopOpen = true;
    }

    public void CloseShopUI()
    {
        shopUI.SetActive(false);
        playerAnimator.enabled = true;
        Time.timeScale = 1f;
        shopOpen = false;
    }
}
