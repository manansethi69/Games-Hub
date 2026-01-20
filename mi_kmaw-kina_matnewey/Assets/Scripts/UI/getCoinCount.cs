using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class getCoinCount : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    void Start()
    {
        coinText = GetComponent<TextMeshProUGUI>();

        if (MainManager.Instance != null) {
            coinText.text = MainManager.Instance.coinInventory.ToString();
        }
        else {
            //MainManager.Instance.coinInventory = 0;
            coinText.text = "0".ToString();
            Debug.Log("Main manager is null.");
        }
    }
}
