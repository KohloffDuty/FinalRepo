using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectableManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI collectedItemsText; // UI text for displaying collected items
    private int collectedCount = 0; // Tracks the number of items collected

    private void Start()
    {
        // Initialize the UI to display the starting count
        UpdateCollectedItemsUI();
    }

    // Call this method to increase the collected items count
    public void AddCollectedItem()
    {
        collectedCount++; // Increment the count
        UpdateCollectedItemsUI(); // Update the UI
    }

    // Updates the UI text to reflect the current count
    private void UpdateCollectedItemsUI()
    {
        if (collectedItemsText != null)
        {
            collectedItemsText.text = $"Items Collected: {collectedCount}";
        }
        else
        {
            Debug.LogWarning("Collected Items Text is not assigned in the Inspector!");
        }
    }

    // Call this method to reset the count and UI
    public void ResetCollectedCount()
    {
        collectedCount = 0; // Reset the count
        UpdateCollectedItemsUI(); // Reset the UI
    }
}
