using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 10f;
    public float speed = 20f; // Speed of the projectile

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Set initial forward velocity to ensure it only goes forward
        rb.velocity = transform.forward * speed;

        // Freeze rotation to prevent the projectile from rotating
        rb.freezeRotation = true;
    }

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
