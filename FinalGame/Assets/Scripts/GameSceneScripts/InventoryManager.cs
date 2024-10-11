using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    public List<Item> inventory = new List<Item>();
    public GameObject inventoryPanel;
    public GameObject descriptionPanel;

    private Item currentItem;

    public void AddItem(Item item)
    {
        inventory.Add(item);
        ShowItemDescription(item);
    }

    public void RemoveItem(Item item)
    {
        inventory.Remove(item);
        // Logic to place item back in the world if needed
    }

    public void ShowItemDescription(Item item)
    {
        currentItem = item;
        descriptionPanel.SetActive(true);
        inventoryPanel.SetActive(false);
        // Display item description in UI (You can add Text components in description panel)
    }

    public void ConfirmAddToInventory()
    {
        descriptionPanel.SetActive(false);
        inventoryPanel.SetActive(true);
        // Add to inventory UI
    }

    public void PutItemBack()
    {
        descriptionPanel.SetActive(false);
        // Logic to place item back in the world
    }
}

