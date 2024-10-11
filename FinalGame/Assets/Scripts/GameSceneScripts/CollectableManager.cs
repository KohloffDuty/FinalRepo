using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectableManager : MonoBehaviour
{
    public TextMeshProUGUI collectedItemsText; 
    private int collectedCount = 0; 
    public void UpdateCollectedItems()
    {
        collectedCount++; 
        collectedItemsText.text = "Items Collected: " + collectedCount.ToString(); // Update the UI Text
    }
}
