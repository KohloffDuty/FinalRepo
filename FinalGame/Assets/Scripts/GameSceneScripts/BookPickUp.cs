using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookPickUp : MonoBehaviour
{



    public GameObject descriptionPanel;

    
    public Text descriptionText;

    // The description that will be displayed when the player picks up the book
    public string bookDescription = "This is the ancient tome, full of secrets and forgotten knowledge...";

    // Check if the player is nearby
    private bool isPlayerNearby = false;

    void Start()
    {
        // Ensure the description panel is hidden at the start
        descriptionPanel.SetActive(false);
    }

    void Update()
    {
        // Check if the player is pressing the interact key and is near the book
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            PickUpBook();
        }
    }

    // This method is called when the player picks up the book
    void PickUpBook()
    {
        // Show the description panel and update the text
        descriptionPanel.SetActive(true);
        descriptionText.text = bookDescription;

        // Optionally, destroy or disable the book object after pickup
        gameObject.SetActive(false); // Or Destroy(gameObject);
    }

    // Detect when the player is within the book's trigger collider
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    // Detect when the player leaves the book's trigger collider
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}



    
