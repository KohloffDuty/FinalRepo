using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    // Create a list to hold the collected items
    private List<string> items = new List<string>();

    void Start()
    {
        Debug.Log("Welcome to the Item Collector!");
        CollectItems();
    }

    void CollectItems()
    {
        string userInput;

        do
        {
            Debug.Log("\nMenu:");
            Debug.Log("1. Add an item");
            Debug.Log("2. View collected items");
            Debug.Log("3. Exit");
            userInput = GetUserInput();

            switch (userInput)
            {
                case "1":
                    // Add an item
                    string item = GetItemInput();
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        items.Add(item);
                        Debug.Log($"Item '{item}' has been collected!");
                    }
                    else
                    {
                        Debug.Log("Item name cannot be empty.");
                    }
                    break;

                case "2":
                    // View collected items
                    ViewCollectedItems();
                    break;

                case "3":
                    // Exit the program
                    Debug.Log("Exiting the Item Collector. Goodbye!");
                    break;

                default:
                    Debug.Log("Invalid option. Please choose 1, 2, or 3.");
                    break;
            }

        } while (userInput != "3");
    }

    string GetUserInput()
    {
        // This method should be implemented to get input from the user.
        return ""; // Placeholder for actual input handling logic.
    }

    string GetItemInput()
    {
        // This method should be implemented to get item input from the user.
        return ""; // Placeholder for actual item input handling logic.
    }

    void ViewCollectedItems()
    {
        Debug.Log("\nCollected Items:");
        if (items.Count > 0)
        {
            foreach (var collectedItem in items)
            {
                Debug.Log($"- {collectedItem}");
            }
        }
        else
        {
            Debug.Log("No items collected yet.");
        }
    }
}