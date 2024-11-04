using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 50f;   // Maximum health of the enemy
    public Text tooltipText;        // Reference to the Text component for the tooltip
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;  // Initialize current health
        UpdateTooltip("Enemy Health: " + currentHealth); // Display initial health
        tooltipText.gameObject.SetActive(false); // Hide tooltip initially

        if (tooltipText == null)
        {
            Debug.LogError("TooltipText is not assigned in the Inspector for " + gameObject.name);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // Reduce health by the damage amount
        UpdateTooltip("Enemy Health: " + currentHealth); // Show updated health
        tooltipText.gameObject.SetActive(true); // Show tooltip when damaged

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        UpdateTooltip("Enemy has been destroyed."); // Update tooltip on death
        Debug.Log("Enemy has died.");
        Destroy(gameObject, 1f); // Give time for tooltip display before destruction
    }

    private void UpdateTooltip(string message)
    {
        if (tooltipText != null)
        {
            tooltipText.text = message;
            tooltipText.transform.position = transform.position + new Vector3(0, 2, 0); // Position tooltip above the enemy
        }
    }

    private void LateUpdate()
    {
        if (tooltipText != null && tooltipText.gameObject.activeSelf)
        {
            tooltipText.transform.LookAt(Camera.main.transform); // Face the camera
            tooltipText.transform.Rotate(0, 180, 0); // Flip the text so it isn't backwards
        }
    }
}
