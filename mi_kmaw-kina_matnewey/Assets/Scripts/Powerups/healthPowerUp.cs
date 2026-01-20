using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class healthPowerUp : MonoBehaviour
{
    public int coinsNeeded = 0;
    public int healthToAdd = 1;
    public healthcontrol playerHealth;
    public int playerCoins;
    Button healthPowerUpBtn;
    public bool valid;

    void Start()
    {   
        //get health object
        playerHealth = GameObject.FindGameObjectWithTag("healthasset").GetComponent<healthcontrol>();

        //instantiate buttons and add listener
        healthPowerUpBtn = GetComponent<Button>();
        if (healthPowerUpBtn != null) {
            healthPowerUpBtn.onClick.AddListener(onButtonClick); 
        }
    }

    void LateUpdate() {
        valid = !((playerHealth.getHealth() + healthToAdd) > playerHealth.getMaxHealth());
    }

    public bool getValid() {
        return valid;
    }

    //on button click, increment health based on health power up clicked given the player has enough coins
    void onButtonClick() {
        /*
        if((playerHealth.playerHealth + healthToAdd) > 3) {
            healthToAdd = Math.Abs(playerHealth.playerHealth - healthToAdd);
            if(playerHealth.playerHealth >= 3) {
                healthToAdd = 0;
            }
        } */
        valid = !((playerHealth.getHealth() + healthToAdd) > playerHealth.getMaxHealth());
        if (valid) {
            playerHealth.updateHealthUI(healthToAdd);
        }
    }
}
