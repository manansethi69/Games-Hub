using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public abstract class powerupsPerm : MonoBehaviour
{   
    public ShopItem shop;
    // what the powerup does
    public abstract void what();

    void Update(){
        if(shop.powerUpAdd){
            what();
            shop.powerUpAdd = false;
        }
    }

}
