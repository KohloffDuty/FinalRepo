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
