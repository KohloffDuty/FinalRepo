using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 20f;  
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Enemy"))
        {
            
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
             
                enemyHealth.TakeDamage(damage);
                Debug.Log("Projectile hit the enemy! Dealt " + damage + " damage.");
            }

           
            Destroy(gameObject);
        }
        
    }
}
