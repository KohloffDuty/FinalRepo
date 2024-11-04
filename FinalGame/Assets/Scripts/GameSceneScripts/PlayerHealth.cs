using UnityEngine;
using UnityEngine.UI; // Add this if you're using Text, or TMPro if using TextMeshPro

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public Transform respawnPoint;
    public Text healthText; // Reference to the UI Text component (or use TextMeshPro)
    private float currentHealth;
    private Rigidbody rb;

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI(); // Initialize the health display
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Player took damage: " + damage + " | Current Health: " + currentHealth);

        UpdateHealthUI(); // Update the health display after taking damage

        if (currentHealth <= 0)
        {
            DieAndRespawn();
        }
    }

    private void DieAndRespawn()
    {
        Debug.Log("Player has died. Respawning");
        currentHealth = maxHealth;
        UpdateHealthUI(); // Reset health display when respawning

        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.position = respawnPoint.position;
            rb.rotation = respawnPoint.rotation;
        }
        else
        {
            transform.position = respawnPoint.position;
            transform.rotation = respawnPoint.rotation;
        }
    }

    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString("F0"); // Display as integer
        }
    }
}
