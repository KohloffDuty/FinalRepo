using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Item item; // Reference to the item to be picked up

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Something collided with the item."); // Log when something collides

        // Check if the object colliding with the item is the player
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Player collided with the item."); // Log when the player collides

            // Get the Inventory component attached to the player
            Inventory inventory = collision.collider.GetComponent<Inventory>();

            // Check if the inventory exists and has space for this item
            if (inventory != null && inventory.HasSpace(item))
            {
                Debug.Log("Item picked up and added to inventory.");

                // Add the item to the player's inventory
                inventory.AddItem(item);

                // Destroy the item in the scene after pickup
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Inventory is full, cannot pick up item.");
            }
        }
    }
}
