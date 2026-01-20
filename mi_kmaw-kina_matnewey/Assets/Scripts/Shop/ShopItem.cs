using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;
using System;

public class ShopItem : MonoBehaviour
{
    public int price;
    public string itemName;
    public Sprite itemImage;
    
    private healthcontrol health;
    private GameObject player;

    private Button button;

    public bool powerUpAdd = false;

    // Start is called before the first frame update
    void Start()
    {
        //Get all TextMeshPro elements in children
        var uiTextElements = GetComponentsInChildren<TextMeshProUGUI>();
        //Set the name and price to align with the public vars
        //DEPENDS on the name of each TextMeshPro gameobject to match ItemName and ItemCost
        foreach(TextMeshProUGUI elem in uiTextElements)
        {
            if(elem.name == "ItemName")
            {
                elem.text = itemName;
            } else if(elem.name == "ItemCost")
            {
                elem.text = price.ToString();
            }
        }

        //Set the image for the item to the public var
        var uiImages = GetComponentsInChildren<Image>();
        foreach(Image img in uiImages)
        {
            if(img.name == "ItemImage")
            {
                img.sprite = itemImage;
            }
        }

        //Get the button element
        button = GetComponent<Button>();

        player = GameObject.Find("Player");
        health = player.GetComponent<healthcontrol>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Disable this button if the player doesn't have enough coins to buy it
        if(MainManager.Instance.coinInventory < price)
        {
            button.interactable = false;
        } else
        {
            button.interactable = true;
        }
    }

    public void BuyItem()
    {
        if( itemName == "Refill Health"){
        if( health.getHealth() < health.getMaxHealth()){
        //Subtract coins from player's inventory
        player.GetComponent<coinCollector>().changeScore(-price);
        //Activate powerup/item
        powerUpAdd = true;
        
        RefillPlayerHealth();
        }
    }
        if( itemName == "Health Increase"){
        
        //Subtract coins from player's inventory
        player.GetComponent<coinCollector>().changeScore(-price);
        //Activate powerup/item
        powerUpAdd = true;
        
        HealthIncrease();
        
    }

        if(itemName == "Speed Up"){

        //Subtract coins from player's inventory
        player.GetComponent<coinCollector>().changeScore(-price);
        //Activate powerup/item
        powerUpAdd = true;

        SpeedUp();    
        }

        

    }

    public void RefillPlayerHealth(){
        int currentHealthToGain = health.getMaxHealth() - health.getHealth();
        if( currentHealthToGain != 0){
            health.updateHealthUI(currentHealthToGain);
        }
    }

    public void HealthIncrease(){
        health.updateHealthUI(health.getHealth()); 
    }

    public void SpeedUp(){
        PlayerMovement updatePlayerMovement = player.GetComponent<PlayerMovement>();
        updatePlayerMovement.runSpeed = 60f;
    }

    
}
