using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addPowerUPtoInventory : MonoBehaviour
{
   // The one bool you set up true is the type of AddItem you want to use
    // The specificItemGive let's you set up a specific Item and quantity to add to the Inventory
    // The randomItemGive let's you choose from a range of items to randomly add to the Inventory
    public bool specificItemGive, randomItemGive;

    // In case of random, this list becomes active in the Editor
    public List<powerUpInventoryData> itemsToGive = new List<powerUpInventoryData>();
    public List<GameObject> powerUps = new List<GameObject>();

    // In case of specific, this two parameters become active in the Editor
    public powerUpInventoryData specificItem;
    public int specificQuant;

    public GameObject powerUp;
    public powerUpInventory inventory;

    void Start(){
        inventory = powerUpInventory.instance;
    }
    // AddItem() is currenlty called by a UI button but you can call it from other script in the same GameObject by using:
    // GetComponent<AddItemToInventory>().AddItem();
    // Don't forget to set up the item you want to give in the Editor

   
    public void AddItem()
    {
        if(specificItemGive && randomItemGive == false)
        {
            AddSpecificItem();
        }
    }

    // Adds the specific item and quantity you set up in the Editor to the Inventory
   void AddSpecificItem()
    {
        inventory.AddItem(specificItem, specificQuant, powerUp);
    }

}
