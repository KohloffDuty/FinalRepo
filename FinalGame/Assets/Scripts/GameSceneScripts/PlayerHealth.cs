using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public Transform respawnPoint;
    private float currentHealth;
    private Rigidbody rb;
    public float GetCurrentHealth()
    {
        return currentHealth;
    }
    private void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Player took damage: " + damage + " | Current Health: " + currentHealth);


        if (currentHealth <= 0)
        {
            DieAndRespawn();
        }
    }

    private void DieAndRespawn()
    {
        Debug.Log("Player has died.Respawning");
        currentHealth = maxHealth;

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
}

