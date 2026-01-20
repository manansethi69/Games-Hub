using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthRefill : powerupsPerm
{

    private healthcontrol health;

    private void Awake()
    {
        health = GameObject.Find("Player").GetComponent<healthcontrol>();
    }

    public override void what() {

        if (health.playerHealth < health.getMaxHealth())
        {
            health.playerHealth++;
            health.addhealth(); // Ensure new hearts are added if necessary
            health.UpdateHealth(); // Update health UI   
        }
    }
    
}
