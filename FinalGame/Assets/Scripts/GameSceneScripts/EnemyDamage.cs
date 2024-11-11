using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damageAmount = 20f;  
    public float damageCooldown = 1f; 
    private float nextDamageTime = 0f; 

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            
            if (Time.time >= nextDamageTime)
            {
                
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

                if (playerHealth != null)
                {
                   
                    playerHealth.TakeDamage(damageAmount);
                    Debug.Log("Enemy dealt " + damageAmount + " damage to the player.");
                }

                
                nextDamageTime = Time.time + damageCooldown;
            }
        }
    }
}
