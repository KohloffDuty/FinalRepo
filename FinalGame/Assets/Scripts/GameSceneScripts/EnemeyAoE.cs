using UnityEngine;

public class AoEEnemy : MonoBehaviour
{
    public float attackDamage = 10f; // Damage dealt within the AoE
    public float attackInterval = 2f; // Time between AoE attacks
    public float detectionRadius = 5f; // Radius for detecting players
    public GameObject aoeEffect; // Optional: Visual effect for the AoE attack

    private float nextAttackTime = 1f; // Timer for the next attack
    private bool playerInRange = false;

    private void Update()
    {
        if (playerInRange && Time.time >= nextAttackTime) 
        {
            // Perform AoE attack
            AoEAttack();
            nextAttackTime = Time.time + attackInterval; // Reset attack timer
        }
    }

    private void AoEAttack()
    {
        // Optionally instantiate an effect (e.g., a visual explosion)
        if (aoeEffect != null)
        {
          GameObject effect = Instantiate(aoeEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
        }

        // Deal damage to all players within range
        Collider[] hitPlayers = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (var player in hitPlayers)
        {
            if (player.CompareTag("Player")) // Ensure it's the player
            {
                PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(attackDamage); // Deal damage
                    Debug.Log("Player hit in AoE! Damage dealt: " + attackDamage);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure it is the player
        {
            playerInRange = true; // Player has entered the attack range
            Debug.Log("Player detected! Ready to attack...");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure it is the player
        {
            playerInRange = false; // Player has left the attack range
            Debug.Log("Player out of range.");
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize the detection radius in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
