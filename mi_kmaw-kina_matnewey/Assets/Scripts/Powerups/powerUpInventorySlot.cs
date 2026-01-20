using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class powerUpInventorySlot : MonoBehaviour
{
    //The item on the slot, if it's null the slot is considered empty
    powerUpInventoryData item;

    // Each slots shows the icon and mi'kmaq of that item, the following are the references to those on the UI
    public Image itemImage;
    public Text powerupName;

    public GameObject powerUpObject;
    // The remove Button is where the player clicks to remove the item in this slot
    public Button removeButton;

    void Start() {
        powerUpInventory.instance.UpdateInventoryUI();
    }


    // The following function is called everytime an item is added or removed from the inventory
    public void UpdateSlot(powerUpInventoryData itemInSlot, int quantityInSlot, GameObject powerup)
    {
        item = itemInSlot;

        // If the item is null or the quantity 0 the slot is considered empty

        if (itemInSlot != null && quantityInSlot !=0)
        {
            // Slot has item: Enable the icon and Remove Button

            removeButton.enabled = true;
            itemImage.enabled = true; 
            powerupName.enabled = true;

            itemImage.sprite = itemInSlot.icon;
            powerupName.text = itemInSlot.powerupName;
            powerUpObject = powerup;
        }
        else
        {
            // Slot Empty: Disable the Icon, quantity and Remove Button
            
            removeButton.enabled = false;
            itemImage.enabled = false;
            powerupName.enabled = false;
        }
    }

    // Called when the player pressed the slot of the item(You can call it in other ways)
    public void UseItem()
    {
        //Checks if there is an item in the slot
        if (item != null)
        {
            // Use the item by calling the function of that specific item
            powerUpObject.GetComponent<powerupTemp>().what();
            RemoveItem();
        }
    }

    // Called when the player presses the Remove Button corresponding to this slot
    public void RemoveItem()
    {
        // Removes item from the Inventory Script and consequently updates the UI(This occurs inside of RemoveItem())
        // Currently removing one piece on stackable objects
        powerUpInventory.instance.RemoveItem(powerUpInventory.instance.itemList[powerUpInventory.instance.itemList.IndexOf(item)], 1, powerUpInventory.instance.powerUps[powerUpInventory.instance.powerUps.IndexOf(powerUpObject)]);
    }

    
}
