using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string itemName;
    public Item item;

    private bool isCollected = false;
    private CollectableManager collectableManager;
    private Inventory playerInventory;
    private void Start()
    {

        collectableManager = FindObjectOfType<CollectableManager>();
        playerInventory = FindObjectOfType<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isCollected && other.CompareTag("Player"))
        {
            CollectItem();
        }
    }

    private void CollectItem()
    {
        isCollected = true;
        Debug.Log("Collected: " + itemName);


        if (playerInventory != null && item != null)
        {
            playerInventory.AddItem(item);
        }


        if (collectableManager != null)
        {
            collectableManager.UpdateCollectedItems();
        }

        gameObject.SetActive(false);

    }
}
  