using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Find the CollectableManager and update the count
            FindObjectOfType<CollectableManager>().AddCollectedItem();
            Destroy(gameObject); // Destroy the collectable
        }
    }
}
