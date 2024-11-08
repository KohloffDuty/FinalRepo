using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using static UnityEditor.Progress;

public class InventoryUI : MonoBehaviour
{
    public GameObject itemSlotPrefab;
    public Transform itemGrid;
    public Inventory playerInventory;
    public ItemDetailsUI detailsUI;

    private Dictionary<string, GameObject> itemSlots = new Dictionary<string, GameObject>();

    private void Start()
    {
        UpdateUI();
    }

    public void OnItemSelected(Item item)
    {
        detailsUI.ShowItemDetails(item);
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
            
            Text quantityText = slot.GetComponentInChildren<Text>();   
            if (quantityText != null )
            {
                quantityText.text = item.quantity.ToString();
            }

            else
            {
                Debug.LogError("QuantityText Component not found in the itemSlotPrefab");
            }

           // slot.transform.Find("QuantityText").GetComponent<Text>().text = item.quantity.ToString();

            itemSlots[item.itemName] = slot;
        }
    }
}
