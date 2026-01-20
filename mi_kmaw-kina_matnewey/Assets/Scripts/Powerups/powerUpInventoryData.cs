using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu(menuName ="powerUpItem")]
public class powerUpInventoryData : ScriptableObject
{
    public string id;
    public string powerupName;
    public Sprite icon;
    public GameObject powerupObject;

    public virtual void Use()
    {
        //Use item
        //Use the following line if you want to destroy every item after use
        // powerupObject.GetComponent<powerupTemp>().what();
        powerUpInventory.instance.RemoveItem(this, 1, powerupObject);
    }
    public bool Stackable = true;

}
