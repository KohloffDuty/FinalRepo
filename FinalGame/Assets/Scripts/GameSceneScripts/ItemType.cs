using UnityEngine;

public enum ItemType { Grenade, PowerUp, Weapon }

[System.Serializable]
public class Item
{
    public string itemName;
    public ItemType itemType;
    public int quantity;
    public Sprite icon;
    public string description;

   
    public Item(string name, ItemType type, int quantity, Sprite icon)
        
    {
        itemName = name;
        itemType = type;
        this.quantity = quantity;
        this.icon = icon;
        this.description = description;

    }
}
