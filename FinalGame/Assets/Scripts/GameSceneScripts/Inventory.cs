using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryUIPanel;
    public List<Item> items = new List<Item>();
    public int maxGrenades = 8;
    public int maxPowerUps = 3;

    private InventoryUI inventoryUI;  // Cache reference to InventoryUI

    // Clear inventory when the game starts
    private void Start()
    {
        if (inventoryUIPanel != null)
        {
            inventoryUIPanel.SetActive(false); // Ensure UI is off initially
        }
        items.Clear();  // Make sure inventory starts empty

        // Cache the InventoryUI reference for better performance
        inventoryUI = FindObjectOfType<InventoryUI>();
        if (inventoryUI == null)
        {
            Debug.LogError("InventoryUI not found in the scene! Make sure it is assigned.");
        }
    }

    // Toggle inventory UI and update the UI with the latest inventory state
    public void ToggleInventoryUI()
    {
        if (inventoryUIPanel != null)
        {
            bool isActive = inventoryUIPanel.activeSelf;
            inventoryUIPanel.SetActive(!isActive);
            if (!isActive && inventoryUI != null)
            {
                inventoryUI.UpdateUI(); // Update UI on open
            }
        }
    }

    // Add an item to the inventory
    public void AddItem(Item item)
    {
        if (inventoryUI == null)
        {
            Debug.LogError("InventoryUI reference is null in AddItem method!");
            return;
        }

        // Check if there's space for the item
        if (HasSpace(item))
        {
            Item existingItem = items.Find(i => i.itemName == item.itemName);

            if (existingItem != null)
            {
                existingItem.quantity += item.quantity;  // Update quantity
            }
            else
            {
                items.Add(item);  // Add new item to inventory
            }

            EnforceLimits(item);
            inventoryUI.UpdateUI();  // Update the UI after adding item
        }
        else
        {
            Debug.Log("No space for this item type in the inventory.");
        }
    }

    // Ensure no item exceeds its quantity limit
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

    // Check if the inventory has space for a given item
    public bool HasSpace(Item item)
    {
        if (item.itemType == ItemType.Grenade)
        {
            Item grenadeItem = items.Find(i => i.itemType == ItemType.Grenade);
            return grenadeItem == null || grenadeItem.quantity < maxGrenades;
        }
        else if (item.itemType == ItemType.PowerUp)
        {
            Item powerUpItem = items.Find(i => i.itemType == ItemType.PowerUp);
            return powerUpItem == null || powerUpItem.quantity < maxPowerUps;
        }
        return true;  // No limits for other item types
    }

    // Use an item (decrease quantity and remove it if it's zero)
    public void UseItem(string itemName)
    {
        if (inventoryUI == null)
        {
            Debug.LogError("InventoryUI reference is null in UseItem method!");
            return;
        }

        Item item = items.Find(i => i.itemName == itemName);
        if (item != null && item.quantity > 0)
        {
            item.quantity--;
            if (item.quantity <= 0)
            {
                items.Remove(item);  // Remove item from inventory if quantity is 0
            }
            inventoryUI.UpdateUI();  // Update UI after using an item
        }
    }
}
