using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private int damage ;

    private healthcontrol health;

    [SerializeField] public game_over_text_UI gameOver;


    private void Awake()
    {
        health = GameObject.Find("Player").GetComponent<healthcontrol>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("eee");
            Damage();
        }

    }

    public void Damage()
    {
        Debug.Log("player is damaged");


        health.playerHealth = health.playerHealth - damage;
        health.UpdateHealth();
        health.death();
    }
}
