using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedUp : powerupTemp
{
    public PlayerMovement movement;

    private void Awake()
    {
        movement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    public override void what()
    {
        movement.runSpeed = 80;
        time.startTimer(5);
    }
    
    // revert back to normal after the timer ends
    public override void revert(){  
        movement.runSpeed = 40;
    }
}
