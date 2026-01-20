
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "Word")]


// BASE ITEM
public class Item : ScriptableObject
{
    //the english name of the item
    public string itemName;

    //the mi'kmaq name of the item
    public string mikmaqName;

    //a description of the icon
    public string description;

    // The ID of every Item needs to be different in order to be saved and loaded 
    public int ID;

    // The price of an item can be used to set up a shop
    //public int price;


    // If you want an item to be stackable, set this bool True
    public bool Stackable = false;

    // The UI icon of the item 
    public Sprite itemIcon;

    //a separate icon for the tooltip
    public Sprite infoIcon;
    
    public virtual void Use()
    {
        //Use item
        //Use the following line if you want to destroy every item after use
        // Inventory.instance.RemoveItem(this, 1);
    }
}
