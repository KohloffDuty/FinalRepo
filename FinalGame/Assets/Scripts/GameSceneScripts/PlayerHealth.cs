using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public Transform respawnPoint;
   public Slider healthSlider; 
    private float currentHealth;
    private Rigidbody rb;

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI(); 
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Player took damage: " + damage + " | Current Health: " + currentHealth);

        UpdateHealthUI(); 

        if (currentHealth <= 0)
        {
            DieAndRespawn();
        }
    }

    private void DieAndRespawn()
    {
        Debug.Log("Player has died. Respawning");
        currentHealth = maxHealth;
        UpdateHealthUI(); 

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
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    public void RestoreToMaxHealth()
    {
        currentHealth = maxHealth;
        Debug.Log("Playerhealth restored to max");
    }
}
