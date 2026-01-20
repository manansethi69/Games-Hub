using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Invinciblity : powerupTemp
{
    private float rainbowSpeed = 5;

    private float hue;
    private float sat;
    private float bri;
    private GameObject player;
    private SpriteRenderer playerColour;
    GameObject[] enemies;
    GameObject[] groundEnemies;
    private bool invincible = false;
    private bool enemyCheck = false;
    private bool groundEnemyCheck = false;
    
    void Awake()
    {
        player = GameObject.Find("Player");
        playerColour = player.GetComponent<SpriteRenderer>();
        
    }
    // what the powerup does
    public override void what()
    {   
        if(enemyCheck){
            foreach(GameObject enemy in enemies){
                enemy.GetComponent<EnemyHurt>().damage = 0;
            }
        }
        if(groundEnemyCheck){
            foreach(GameObject groundEnemy in groundEnemies){
                groundEnemy.GetComponent<enviroHurt>().damage = 0;
            }
        }
        sat = 1;
        bri = 1;
        playerColour.color = Color.HSVToRGB(hue, sat, bri);
        invincible = true;
        time.startTimer(5);
        
    }

    
    // revert back to normal after the timer ends
    public override void revert(){
        if(groundEnemyCheck){
            foreach(GameObject groundEnemy in groundEnemies){
                groundEnemy.GetComponent<enviroHurt>().damage = 1;
            }
        }
        if(enemyCheck){
            foreach(GameObject enemy in enemies){
                enemy.GetComponent<EnemyHurt>().damage = 1;
            }
        }
        invincible = false;
        playerColour.color = Color.white;
    }

    new void Update(){
        if(shopItem.powerUpAdd){
            powerUp.AddItem(powerUpItem, 2, this.gameObject);
            shopItem.powerUpAdd = false;
        }
        
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        groundEnemies = GameObject.FindGameObjectsWithTag("GroundEnemy");
        if(enemies.Length > 0){
            enemyCheck = true;
        }
        if(groundEnemies.Length > 0){
            groundEnemyCheck = true;
        }
        if(invincible){
            // Debug.Log("working");
            hue += rainbowSpeed /1000;
            if (hue >= 1){
                hue = 0;
            }
            
            playerColour.color = Color.HSVToRGB(hue,sat,bri);
            if(time.currentTime < 0){
                revert();
            }
            
        }
    }
}
