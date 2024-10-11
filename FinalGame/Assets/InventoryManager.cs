using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    public List<Item> inventory = new List<Item>();  // List to hold inventory items

    // Singleton Pattern to access inventory globally
    public static InventoryManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);  // Keep inventory persistent between scenes
    }

    // Method to add an item to the inventory
    public void AddItem(Item item)
    {
        inventory.Add(item);
        Debug.Log("Added: " + item.itemName);
    }

    // Method to remove an item from the inventory
    public void RemoveItem(Item item)
    {
        if (inventory.Contains(item))
        {
            inventory.Remove(item);
            Debug.Log("Removed: " + item.itemName);
        }
    }
}

