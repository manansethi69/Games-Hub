using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showHint : MonoBehaviour
    
{
    private GameObject hint;
    private GameObject notEnoughCoins;
    public bool active;
    public coinCollector collector;

    private void Awake()
    {
        hint = GameObject.Find("HintImage");

        if (hint == null)
        {
            Debug.LogError("Hint Image UI object Not Found!");
        }
        
        notEnoughCoins = GameObject.Find("notEnoughCoins");

        if (notEnoughCoins == null)
        {
            Debug.LogError("Not Enough Coins UI object Not Found!");
        }

        collector = gameObject.GetComponent<coinCollector>();

        if (collector == null)
        {
            Debug.LogError("Coin Collector script Not Found!");
        }

    }

    //sets the objects to false on start
    public void Start()
    {
        notEnoughCoins.SetActive(false);
        hint.SetActive(false);
        active = false;
    }

    //if the player has at least 3 coins, you can buy a hint. If not, a UI will appear letting the player know.
    public void Show()
    {
        if (collector.score < 3)
        {
            notEnoughCoins.SetActive(true);
            StartCoroutine(wait());
        }
        else
        {
            hint.SetActive(true);
            active = true;
            collector.changeScore(-3);
            Invoke("turnOff", 3f);
        }
    }
    //called to let the player know they dont have enough coins
    private void turnOff(){
        hint.SetActive(false);
        active = false;
    }

    //method to wait 2 seconds and deactivate the not enough coins UI
    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        notEnoughCoins.SetActive(false);
    }
}
