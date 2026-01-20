using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopButton : MonoBehaviour
{
    GameObject shopMenu;
    Button shopButton;
    bool active = false;
    TextMeshProUGUI buttonText;

    void Start()
    {
        shopMenu = GameObject.Find("ShopMenu");
        shopButton = GetComponent<Button>();
        buttonText = shopButton.GetComponentInChildren<TextMeshProUGUI>(true);

        if (shopMenu != null) { shopMenu.SetActive(active); }
        if (shopButton != null) { shopButton.onClick.AddListener(OnButtonClick); }
    }

    void OnButtonClick()
    {
        active = !active;
        shopMenu.SetActive(active);

        buttonText.text = (active? "Close Shop": "Shop");
        if (active) { Time.timeScale = 0; }
        else { Time.timeScale = 1; }
    }


}
