using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// IN THIS SCRIPT: Inventory Main Script that handles items and respective quantities aqquired
// WARNING: This script uses UNITY Editor to simplify the process of setting it up
// USE THIS SCRIPT by attaching it to any GameObject(Ex. PlayerPrefab, EmptyObject)
public class powerUpInventory : MonoBehaviour
{
 
    // The items on the inventory
    public List<powerUpInventoryData> itemList = new List<powerUpInventoryData>();

    public List<GameObject> powerUps = new List<GameObject>();

    // The correponding quantities of each item
    public List<int> quantityList = new List<int>();


    // The inventoryPanel is the parent object of each slot
    public GameObject inventoryPanel;

    // The slotList is the list of slots on the inventory, you can turn this List public and place the slots manually inside of it
    // Currently it's making the list based on the inventoryPanel children objects on GatherSlots() in line 86
  List<powerUpInventorySlot> slotList = new List<powerUpInventorySlot>();


    #region Singleton

    public static powerUpInventory instance;

    void Awake()
    {
        instance = this;
    }

    #endregion


    public void Start()
    {
        // Add the slots of the Inventory Panel to the list

        foreach (powerUpInventorySlot child in inventoryPanel.GetComponentsInChildren<powerUpInventorySlot>())
        {
            slotList.Add(child);
        }



    }
    // AddItem() can be called in other scripts with the following line:
    //Inventory.instance.Add(ItemYouWantToGiveHere , quantityOfThatItem);
    // Currently it's being called by the AddItemToInventory Script on the Add Items Buttons 
    public void AddItem(powerUpInventoryData itemAdded, int quantityAdded, GameObject powerUp)
    {
        //If the Item is Stackable it checks if there is already that item in the inventory and only adds the quantity
  
        if (itemAdded.Stackable)
        {
            if (itemList.Contains(itemAdded))
            {
                quantityList[itemList.IndexOf(itemAdded)] = quantityList[itemList.IndexOf(itemAdded)] + quantityAdded;
                quantityList[powerUps.IndexOf(powerUp)] = quantityList[powerUps.IndexOf(powerUp)] + quantityAdded;
            }
            else
            {

                if (itemList.Count < slotList.Count)
                {
                    itemList.Add(itemAdded);
                    quantityList.Add(quantityAdded);
                    powerUps.Add(powerUp);
                }
                else { }
               
            }

        }
        else
        {
            for (int i = 0; i < quantityAdded; i++)
            {
                if (itemList.Count < slotList.Count)
                {
                    itemList.Add(itemAdded);
                    quantityList.Add(1);
                    powerUps.Add(powerUp);
                }
                else {  }
               
            }
            
        }
        
        // Update Inventory everytime an item is added
        UpdateInventoryUI();
    }

    // As the previous function, this can be called from another script
    // Currently called by the Remove Button in each powerUpInventorySlot Prefab
    public void RemoveItem(powerUpInventoryData itemRemoved, int quantityRemoved, GameObject powerUpRemoved)
    {
        // If the item is stackable it removes the quantity and if it's 0 or less it removes the item completely from the itemList
        if (itemRemoved.Stackable)
        {
            if (itemList.Contains(itemRemoved))
            {
                quantityList[itemList.IndexOf(itemRemoved)] = quantityList[itemList.IndexOf(itemRemoved)] - quantityRemoved;
                quantityList[powerUps.IndexOf(powerUpRemoved)] = quantityList[powerUps.IndexOf(powerUpRemoved)] - quantityRemoved;

                if (quantityList[itemList.IndexOf(itemRemoved)]<= 0)
                {
                    quantityList.RemoveAt(itemList.IndexOf(itemRemoved));
                    itemList.RemoveAt(itemList.IndexOf(itemRemoved));
                    powerUps.RemoveAt(powerUps.IndexOf(powerUpRemoved));
                }
            }
            
        }
        else
        {

            
            for (int i = 0; i < quantityRemoved; i++)
            {
                quantityList.RemoveAt(itemList.IndexOf(itemRemoved));
                itemList.RemoveAt(itemList.IndexOf(itemRemoved));
                powerUps.RemoveAt(powerUps.IndexOf(powerUpRemoved));
              
            }
        }
        // Update Inventory everytime an item is removed
        UpdateInventoryUI();
    }





    // --------------------------------------------------UI------------------------------------------------


  
    // Everytime an item is Added or Removed from the Inventory, the UpdateInventoryUI runs
    public void UpdateInventoryUI()
    {
        // This int is to count how many slots are full
        int ind = 0;

        // For each slot in the list it's attributed an Item from the itemList and the corresponding quantity
      foreach(powerUpInventorySlot slot in slotList)
        {

            if (itemList.Count != 0)
            {
                // If the ind is greater than the item quantity, the rest is considered empty slot

                if (ind < itemList.Count)
                {
                    // Calls the UpdateSlot() function on the respective slot and attributes the item and quantity of their unique index in the itemList
                    slot.UpdateSlot(itemList[ind], quantityList[ind], powerUps[ind]);
                    ind = ind + 1;
                }
                else
                {
                    //Update Empty Slot
                    slot.UpdateSlot(null, 0, null);
                }
            }
            else
            {
                //Update Empty Slot
                slot.UpdateSlot(null, 0, null);
            }

        }
    }

   
}
