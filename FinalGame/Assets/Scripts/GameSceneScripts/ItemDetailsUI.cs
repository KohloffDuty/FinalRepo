using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemDetailsUI : MonoBehaviour
{
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemDescriptionText;
   
    public void ShowItemDetails(Item item)
    {
        itemNameText.text = item.itemName;
        itemDescriptionText.text = item.description;
       
    }

    public void ClearDetails()
    {
        itemNameText.text = "";
        itemDescriptionText.text = "";
        
    }
}
