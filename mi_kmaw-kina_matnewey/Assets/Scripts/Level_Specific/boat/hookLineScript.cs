using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class hookLineScript : MonoBehaviour
{   
    private UnityEngine.Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float playerSpeed;
    public colourToCatch panel;
    [SerializeField] private healthcontrol health;
    private bool isCorrectFish = false;
    public GameObject fishImpact;


    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        UnityEngine.Vector3 direction = mousePos - transform.position;
        UnityEngine.Vector3 rotation = transform.position - mousePos;
        rb.velocity = new UnityEngine.Vector2(direction.x, direction.y).normalized * playerSpeed;
        //set rotation value of projectile
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = UnityEngine.Quaternion.Euler(0, 0, rot + 90);
        fishImpact = GameObject.Find("WaterSplash");
    }

    public void setColour(colourToCatch colour) {
        panel = colour;
    }
    
    public void attachHealth(healthcontrol health) {
        this.health = health;
    }

    void OnTriggerEnter2D(Collider2D col)
    {   

        //Check for fish tag
        if (col.gameObject.tag == "Fish")
        {   
            FishChecker(col.gameObject);
            //checks the color of the collided fish with the correct color of the fish needed
            if (isCorrectFish){
                panel.setTextColour();
            } else {
                //if the player hit the wrong fish, damage them
                Damage();
            }

            Instantiate(fishImpact, transform.position, transform.rotation);

        } else if (col.gameObject.tag == "Enemy") {
            col.GetComponent<piranha_movement>().resetPosition();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSoundSystem>().KillEnemy();
        }

        Destroy(gameObject);

    }

    //damage script that eliminates the player when they lose hp and also decrements health when damaged
    public void Damage()
    {   
        Debug.Log("player is damaged");
        health.playerHealth = health.playerHealth - 1;
        health.UpdateHealth();
        //input desired level for the player to go to here
        health.levelChange("Level4");
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 1f);
    }

    public void FishChecker(GameObject fish) {
        if(fish.GetComponent<colourChange>().getColour() == panel.GetComponent<colourToCatch>().returnColourToMatch()) {
            isCorrectFish = true;
        }
    }

    public bool getIfCorrectFish() {
        return isCorrectFish;
    }


}
