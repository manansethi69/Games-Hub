using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class itemCostColor : MonoBehaviour
{
    public int coins;
    private TextMeshProUGUI coinText;

    void Start()
    {
        coinText = GetComponent<TextMeshProUGUI>();
        if (MainManager.Instance != null) {
            coins = MainManager.Instance.coinInventory;
        }
        else {
            coins = 0;
        }

        string coinTextWithoutDollar = coinText.text.Replace("$", "");
        int coinTextValue;
        if (int.TryParse(coinTextWithoutDollar, out coinTextValue)) {
            if (coins > coinTextValue) {
                coinText.color = new Color(1.0f, 1.0f, 1.0f); 
            }
            else {
                coinText.color = new Color(1.0f, 0.0f, 0.0f); 
            }
        }
    }

}
