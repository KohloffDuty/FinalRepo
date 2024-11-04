using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 50f;  // Maximum health of the enemy
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth; // Initialize current health
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // Reduce health by the damage amount
        Debug.Log("Enemy took damage: " + damage + " | Current Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy has died.");
        Destroy(gameObject); // Destroy the enemy GameObject
    }
}
