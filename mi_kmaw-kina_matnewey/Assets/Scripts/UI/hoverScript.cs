using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class hoverScript : MonoBehaviour
{
    public TextMeshProUGUI hoverText;
    public TextMeshProUGUI itemText;
    private Button buyButton;
    string text;

    void Start()
    {
        buyButton = GetComponent<Button>();
        text = itemText.text;
        Debug.Log(text);
        hoverText.gameObject.SetActive(false);
    }

    public void OnHoverEnter()
    {
        hoverText.gameObject.SetActive(true);
        
        // Modify text hints based on element hovered over
        if (text.Contains("Pet")) {
            hoverText.text = "Add a Pet Companion To Your Adventure";
        }
        else if (text.Contains("Health")) {
            hoverText.text = "Replenish Your Health";
        }
        else if (text.Contains("Jump")) {
            hoverText.text = "Double Jump Allows You To Reach Higher Places";
        }
        else {
            hoverText.text = "";
        }
    }
    public void OnHoverExit()
    {
        hoverText.gameObject.SetActive(false);
    }
}

