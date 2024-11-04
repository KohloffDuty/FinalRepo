using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the EnemyHealth component
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
            Debug.Log("Enemy took damage");
            Destroy(gameObject); // Destroy the projectile after hitting
        }
    }
}
