using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buyDoubleJump : MonoBehaviour
{
    public int coinsNeeded = 0;
    public int playerCoins = 0;
    Button doubleJumpBtn;
    CharacterController2D playerJump;

    // Start is called before the first frame update
    void Start()
    {
        playerJump = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();

        //instantiate buttons and add listener
        doubleJumpBtn = GetComponent<Button>();
        if (doubleJumpBtn != null) {
            doubleJumpBtn.onClick.AddListener(onButtonClick); 
        }
    }

    private void onButtonClick()
    {
        if(compareCoin(coinsNeeded)) {
            playerJump.allowPlayerDoubleJump();
        }
    }



    bool compareCoin(int coinsToBuy) {
        // Debug.Log(MainManager.Instance);
    

        // if(MainManager.Instance != null) {
            
        //     Debug.Log(MainManager.Instance.coinInventory);
        //     int currentCoins = MainManager.Instance.coinInventory;

        //     if(currentCoins >= coinsToBuy) {
        //         return true;
        //     }
        // }

        return true;
    }
}
