using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pickUp : MonoBehaviour
{
    private int coins;
    public PlayerSoundSystem playerSoundSystem;
    [SerializeField] private int coinValue = 1;

    private void Awake()
    {
        playerSoundSystem = GameObject.Find("Player").GetComponent<PlayerSoundSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            coins+=coinValue;
            //MainManager.Instance.coinInventory += coinValue;
            playerSoundSystem.Coin();
        }
    }
}
