using UnityEngine;

public class healthIncrease : powerupsPerm
{
    private healthcontrol health;
    
    private void Awake()
    {
        health = GameObject.Find("Player").GetComponent<healthcontrol>();
    }
    
    public override void what(){
        health.playerHealth = health.heartCount;
        health.playerHealth++;
        health.addhealth();
        health.UpdateHealth();
    }
}
