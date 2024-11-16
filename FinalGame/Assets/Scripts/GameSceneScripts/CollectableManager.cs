using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectableManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI collectedItemsText; // Use SerializeField for inspector visibility
    private int collectedCount = 0;

    private void Start()
    {
        // Initialize the text to show zero collected items at the start
        UpdateCollectedItemsUI();
    }

    public void UpdateCollectedItems()
    {
        collectedCount++;
        UpdateCollectedItemsUI(); // Update the UI Text
    }

    private void UpdateCollectedItemsUI()
    {
        if (collectedItemsText != null) // Check if the text component is assigned
        {
            collectedItemsText.text = "Items Collected: " + collectedCount.ToString();
        }
        else
        {
            Debug.LogWarning("Collected Items Text is not assigned in the Inspector!");
        }
    }

    public void ResetCollectedCount()
    {
        collectedCount = 0;
        UpdateCollectedItemsUI(); // Reset UI display
    }
}