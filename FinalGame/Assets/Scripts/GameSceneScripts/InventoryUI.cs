using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

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
        if (item.itemType == ItemType.PowerUp)
        {
           
            playerInventory.UseItem(item.itemName);
            FindObjectOfType<PlayerHealth>().RestoreToMaxHealth(); 
        }
        else
        {
           
            detailsUI.ShowItemDetails(item);
        }
    }

    
    public void UpdateUI()
    {
        
        foreach (Transform child in itemGrid)
        {
            Destroy(child.gameObject); 
        }

       
        foreach (Item item in playerInventory.items)
        {
            
            GameObject slot = Instantiate(itemSlotPrefab, itemGrid);

            
            Image iconImage = slot.transform.Find("ItemIcon").GetComponent<Image>();
            if (iconImage != null && item.icon != null)
            {
                iconImage.sprite = item.icon; 
            }

            
            TextMeshProUGUI quantityText = slot.GetComponentInChildren<TextMeshProUGUI>();
            if (quantityText != null)
            {
                quantityText.text = item.quantity.ToString(); 
            }

           
            slot.GetComponent<Button>().onClick.AddListener(() => OnItemSelected(item));

            
            if (itemSlots.ContainsKey(item.itemName))
            {
                itemSlots[item.itemName] = slot; 
            }
            else
            {
                itemSlots.Add(item.itemName, slot); 
            }
        }
    }
}
