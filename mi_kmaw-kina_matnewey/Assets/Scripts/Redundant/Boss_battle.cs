using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_battle : MonoBehaviour
{
    [SerializeField] private int damage ;

    [SerializeField] private healthcontrol health;


    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("123");
        if (collision.CompareTag("Player"))
        {
            Debug.Log("eee");
            Damage();
        }
    }

    void Damage()
    {
        Debug.Log("player is damaged");


        // health.playerHealth = health.playerHealth - damage;
        // health.UpdateHealth();
        // health.death();
    }
}
