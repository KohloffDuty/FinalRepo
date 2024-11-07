using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public int maxGrenades = 5; // Limit for grenades
    public int maxPowerUps = 3; // Limit for power-ups

    // Adds an item to the inventory
    public void AddItem(Item item)
    {
        Item existingItem = items.Find(i => i.itemName == item.itemName);

        if (existingItem != null)
        {
            // Update quantity if the item already exists in the inventory
            existingItem.quantity += item.quantity;
        }
        else
        {
            // Add new item if it doesn't exist in the inventory
            items.Add(item);
        }

        // Enforce maximum limits
        EnforceLimits(item);
    }

    private void EnforceLimits(Item item)
    {
        if (item.itemType == ItemType.Grenade && item.quantity > maxGrenades)
        {
            item.quantity = maxGrenades;
        }
        else if (item.itemType == ItemType.PowerUp && item.quantity > maxPowerUps)
        {
            item.quantity = maxPowerUps;
        }
    }

    // Use an item, e.g., throw a grenade or activate a power-up
    public void UseItem(string itemName)
    {
        Item item = items.Find(i => i.itemName == itemName);
        if (item != null && item.quantity > 0)
        {
            // Logic to use the item in-game
            item.quantity--;

            // Remove item if quantity reaches zero
            if (item.quantity <= 0)
            {
                items.Remove(item);
            }
        }
    }
}
