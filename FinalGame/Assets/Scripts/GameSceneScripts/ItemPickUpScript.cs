using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Item item; // Assign item data in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inventory = other.GetComponent<Inventory>();
            if (inventory != null)
            {
                inventory.AddItem(item);
                Destroy(gameObject); // Remove item from the scene
            }
        }
    }
}
