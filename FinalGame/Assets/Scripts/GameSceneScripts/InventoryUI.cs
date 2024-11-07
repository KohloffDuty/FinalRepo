using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using static UnityEditor.Progress;

public class InventoryUI : MonoBehaviour
{
    public GameObject itemSlotPrefab;
    public Transform itemGrid;
    public Inventory playerInventory;

    private Dictionary<string, GameObject> itemSlots = new Dictionary<string, GameObject>();

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        foreach (Transform child in itemGrid)
        {
            Destroy(child.gameObject); // Clear existing UI elements
        }

        foreach (Item item in playerInventory.items)
        {
            GameObject slot = Instantiate(itemSlotPrefab, itemGrid);
            slot.transform.Find("ItemIcon").GetComponent<Image>().sprite = item.icon;
            slot.transform.Find("QuantityText").GetComponent<Text>().text = item.quantity.ToString();

            itemSlots[item.itemName] = slot;
        }
    }
}
