using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurt : MonoBehaviour
{
    [SerializeField] public int damage = 1;
    
    [SerializeField] public game_over_text_UI gameOver;

    private healthcontrol health;
    
    private void Awake()
    {
        health = GameObject.Find("Player").GetComponent<healthcontrol>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (transform.position.y + 1 >= collision.gameObject.transform.position.y)
            {
                Damage();
            }
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
