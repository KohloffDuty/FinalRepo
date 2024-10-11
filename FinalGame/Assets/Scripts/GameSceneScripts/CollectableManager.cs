using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Required for TextMeshPro

public class CollectableManager : MonoBehaviour
{
    public TextMeshProUGUI collectedItemsText; // Reference to the TextMeshProUGUI component
    private int collectedCount = 0; // Tracks how many items have been collected

    // This function is called whenever an item is collected
    public void UpdateCollectedItems()
    {
        collectedCount++; // Increment the collected items count
        collectedItemsText.text = "Items Collected: " + collectedCount.ToString(); // Update the UI Text
    }
}
