using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class buyItem : MonoBehaviour
{
    public int coins;
    private int itemCost;
    public TextMeshProUGUI coinText;
    private Button buyButton;
    public TextMeshProUGUI scoreUI;
    public bool buyOnce = false;
    private int timesBought = 0;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        buyButton = GetComponent<Button>();

        // Get coin count
        if (MainManager.Instance != null) {
            coins = MainManager.Instance.coinInventory;
        }
        else {
            coins = 0;
        }

        itemCost = getItemCost();

        Button itemButton = GetComponent<Button>();
        if (itemButton != null) {
            itemButton.onClick.AddListener(OnButtonClick); 
        }
        UpdateInteractable();
    }

    void LateUpdate() {
        UpdateInteractable();
    }

    void UpdateInteractable() {
        if (scoreUI == null) {
            Debug.LogError("ScoreUI is not assigned!");
            return;
        }

        if (MainManager.Instance != null) {
            coins = MainManager.Instance.coinInventory;
        }

        // Update the UI
        if (scoreUI != null) {
            scoreUI.text = "Points: " + coins.ToString();
        } else {
            Debug.LogError("Component not found on ScoreUI GameObject.");
        }

        // Update button interactability
        buyButton.interactable = coins >= itemCost && coins > 0 && getHealthValid();

        // Item should only be bought once
        if (timesBought == 0) { buyButton.interactable = true; }
        else if (buyOnce) { buyButton.interactable = false; }
    }


    int getItemCost() {
        string coinTextWithoutDollar = coinText.text.Replace("$", "");
        int coinTextValue;
        bool success = int.TryParse(coinTextWithoutDollar, out coinTextValue);
        if (success) {
            return coinTextValue;
        } else {
            return 0;
        }
    } 

    void OnButtonClick() {
        Debug.Log("Item cost: " + itemCost);
        
        if (MainManager.Instance != null && getHealthValid()) {
            MainManager.Instance.coinInventory = coins - itemCost;
            Debug.Log("Coin inventory: " + MainManager.Instance.coinInventory.ToString());
            timesBought++;
            UpdateInteractable();
        }
        else {
            Debug.Log("No instance of the coin inventory");
        }
    }

    bool getHealthValid() {
        healthPowerUp healthScript = GetComponent<healthPowerUp>(); 
        if (healthScript != null) { return healthScript.getValid(); }
        else { return true; }
    }
}

