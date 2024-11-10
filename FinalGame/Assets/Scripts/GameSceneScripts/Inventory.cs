using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryUIPanel;
    public List<Item> items = new List<Item>();
    public int maxGrenades = 8;
    public int maxPowerUps = 3;

    public void ToggleInventoryUI()
    {
        if (inventoryUIPanel != null)
        {
            bool isActive = inventoryUIPanel.activeSelf;
            inventoryUIPanel.SetActive(!isActive);
            if (!isActive)
            {
                FindObjectOfType<InventoryUI>().UpdateUI(); // Update UI on open
            }
        }
    }

    public void AddItem(Item item)
    {
        // Check if there's space for the item
        if (HasSpace(item))
        {
            Item existingItem = items.Find(i => i.itemName == item.itemName);

            if (existingItem != null)
            {
                existingItem.quantity += item.quantity;
            }
            else
            {
                items.Add(item);
            }

            EnforceLimits(item);
        }
        else
        {
            Debug.Log("No space for this item type in the inventory.");
        }
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

    public bool HasSpace(Item item)
    {
        if (item.itemType == ItemType.Grenade)
        {
            // Find the existing grenade item and check if adding more exceeds the limit
            Item grenadeItem = items.Find(i => i.itemType == ItemType.Grenade);
            return grenadeItem == null || grenadeItem.quantity < maxGrenades;
        }
        else if (item.itemType == ItemType.PowerUp)
        {
            // Find the existing power-up item and check if adding more exceeds the limit
            Item powerUpItem = items.Find(i => i.itemType == ItemType.PowerUp);
            return powerUpItem == null || powerUpItem.quantity < maxPowerUps;
        }

        // For other item types, assume no limit
        return true;
    }

    public void UseItem(string itemName)
    {
        Item item = items.Find(i => i.itemName == itemName);
        if (item != null && item.quantity > 0)
        {
            item.quantity--;
            if (item.quantity <= 0)
            {
                items.Remove(item);
            }
        }
    }

    private void Start()
    {
        if (inventoryUIPanel != null)
        {
            inventoryUIPanel.SetActive(false); // Ensure UI is off initially
        }
    }
}
