using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;         // Reference to the player's transform
    public float moveSpeed = 3f;    // Speed at which the enemy moves
    public float attackDamage = 10f; // Damage dealt on contact with the player

    private bool isChasing = false;  // Flag to indicate if the enemy is chasing the player

    private void Update()
    {
        // If the enemy is chasing, move towards the player
        if (isChasing)
        {
            ChasePlayer();
        }
    }

    private void ChasePlayer()
    {
        // Move towards the player
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the "Player" tag
        {
            isChasing = true; // Start chasing the player
            Debug.Log("Player detected! Chasing...");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the "Player" tag
        {
            isChasing = false; // Stop chasing the player
            Debug.Log("Player left detection zone. Stopping chase.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Ensure the player has the "Player" tag
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage); // Deal damage
                Debug.Log("Player hit! Damage dealt: " + attackDamage);
            }
        }
    }
}
