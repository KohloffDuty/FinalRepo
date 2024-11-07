using UnityEngine;

public class MovingWallTrap : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveDistance = 5f; // Distance the wall will move left and right
    public float moveSpeed = 2f; // Speed of movement

    private Vector3 initialPosition;
    private bool movingRight;

    [Header("Damage and Respawn")]
    public Transform respawnPoint; // Reference to the respawn point
    public int damageAmount = 1; // Amount of damage the wall deals
    private PlayerHealth playerHealth;

    void Start()
    {
        initialPosition = transform.position; // Store initial position
        movingRight = true; // Start moving to the right
        playerHealth = FindObjectOfType<PlayerHealth>(); // Reference to player's health script
    }

    void Update()
    {
        // Calculate the target position
        Vector3 targetPosition = movingRight
            ? initialPosition + Vector3.right * moveDistance
            : initialPosition - Vector3.right * moveDistance;

        // Move the wall towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Change direction when reaching the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            movingRight = !movingRight;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player collides with the wall
        if (collision.gameObject.CompareTag("Player"))
        {
            // Deal damage to the player
            playerHealth.TakeDamage(damageAmount);

            // Respawn the player if health reaches zero
            if (playerHealth.GetCurrentHealth() <= 0)
            {
                collision.gameObject.transform.position = respawnPoint.position;
                playerHealth.GetCurrentHealth();
            }
        }
    }
}
