using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ItemPickup : MonoBehaviour
{
    public Item item;  // Reference to the item

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryManager.instance.AddItem(item);  // Add item to inventory
            Destroy(gameObject);  // Remove the item from the scene
        }
    }
}

