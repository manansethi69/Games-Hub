using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class boatLevelCoinManager : MonoBehaviour
{
  
    public healthcontrol health;
    private int startingCoins = 0;
    public GameObject collectedCoins;
    public colourToCatch panel;
    private boatMovement_noController player;


    // Start is called before the first frame update
    void Start()
    {   
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<boatMovement_noController>();
        collectedCoins = GameObject.Find("CollectedCoins");

        if(MainManager.Instance != null)
        {
            startingCoins = MainManager.Instance.coinInventory;
        }

    }



    private void OnTriggerEnter2D(Collider2D collision){
       
        if(collision.gameObject.CompareTag("Fish")){
            if(GetComponent<hookLineScript>().getIfCorrectFish()) {
                addCoin(4);
                updateCoinCount();
                player.GetComponentInParent<PlayerSoundSystem>().Coin();
            } else {
                player.GetComponentInParent<PlayerSoundSystem>().Damage();
            }
            
        }

    }

    //update the UI in canvas
    public void updateCoinCount(){
        // collectedCoins.GetComponent<TextMeshPro>().text = "Coins: " + player.getCoinCount();
    }
    
    //adjust coin count
    public void addCoin(int coinsToAdd){
        
        if ((coinsToAdd + player.getCoinCount()) >= 0)
        {
           player.incrementPlayerCoins(coinsToAdd);
        } else {
            player.incrementPlayerCoins(-player.getCoinCount());
        }

        if (MainManager.Instance != null)
        {
            MainManager.Instance.coinInventory = player.getCoinCount();
        }
        
    }


    //When player dies, reset coins to what they were at the start of the level.
    void OnDestroy()
    {
        if(health.playerHealth <= 0)
        {
            if (MainManager.Instance != null) {
                MainManager.Instance.coinInventory = startingCoins;
            }
        }
    }

    public void attachHealth(healthcontrol health) {
        this.health = health;
    }

    public void attachPanel(colourToCatch panel) {
        this.panel = panel;
    }

}
