using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemDetailsUI : MonoBehaviour
{
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemDescriptionText;
    public TextMeshProUGUI itemStatsText;
    public Image itemPreviewImage;

    public void ShowItemDetails(Item item)
    {
        itemNameText.text = item.itemName;
        itemDescriptionText.text = item.description;
        itemStatsText.text = $"Power: {item.power}"; // Customize this line based on your item stats
        itemPreviewImage.sprite = item.icon;
    }

    public void ClearDetails()
    {
        itemNameText.text = "";
        itemDescriptionText.text = "";
        itemStatsText.text = "";
        itemPreviewImage.sprite = null;
    }
}
