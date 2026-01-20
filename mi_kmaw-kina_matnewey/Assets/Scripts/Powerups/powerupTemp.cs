using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class powerupTemp : MonoBehaviour
{
    public ShopItem shopItem;
    public powerupTimer time;
    public powerUpInventory powerUp;
    public powerUpInventoryData powerUpItem;

    private void Awake()
    {
        time = GameObject.Find("Powerup Timer").GetComponent<powerupTimer>();

        if (time == null)
        {
            Debug.LogError("Powerup Timer Not Found!!!");
        }
        
        powerUp = GameObject.Find("PowerUpInventory").GetComponent<powerUpInventory>();

        if (powerUp == null)
        {
            Debug.LogError("PowerUpInventory Not Found!!!");
        }
        
    }

    // what the powerup does
    public abstract void what();
    
    // revert back to normal after the timer ends
    public abstract void revert();

    public void Update(){
        if(shopItem.powerUpAdd){
            powerUp.AddItem(powerUpItem, 1, this.gameObject);
            shopItem.powerUpAdd = false;
        }
        if(time.currentTime < 0)
        { 
            revert();

        }
    }

}
