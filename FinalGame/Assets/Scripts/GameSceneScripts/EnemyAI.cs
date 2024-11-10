using UnityEngine;

public class EnemyFollowIng : MonoBehaviour
{
    public Transform player;            // Reference to the player's transform
    public float detectionRange = 10f;  // Range within which the enemy can detect the player
    public float moveSpeed = 3f;        // Speed at which the enemy moves
    public Transform pointA;            // First patrol point
    public Transform pointB;            // Second patrol point
    private Vector3 targetPosition;     // Current target position for patrolling
    private bool movingToPointA = true; // Flag to track which point to move towards

    void Start()
    {
        // Set the initial target position to point A
        targetPosition = pointA.position;
    }

    void Update()
    {
        // Check if the player is within detection range
        if (Vector3.Distance(transform.position, player.position) <= detectionRange)
        {
            // Chase the player
            ChasePlayer();
        }
        else
        {
            // Patrol between points A and B
            Patrol();
        }
    }

    void Patrol()
    {
        // Move towards the current target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Check if we have reached the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Switch target position between point A and B
            if (movingToPointA)
            {
                targetPosition = pointB.position;
            }
            else
            {
                targetPosition = pointA.position;
            }
            movingToPointA = !movingToPointA; // Toggle the flag
        }
    }

    void ChasePlayer()
    {
        // Move towards the player's position
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        // Optionally: Rotate to face the player
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}