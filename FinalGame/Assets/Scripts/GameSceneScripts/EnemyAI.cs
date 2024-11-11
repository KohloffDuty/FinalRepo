using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAITrigger : MonoBehaviour
{
    public Transform player;            // Reference to the player's transform
    public Transform pointA;            // First patrol point
    public Transform pointB;            // Second patrol point
    public float detectionRange = 10f;  // Trigger radius for detection
    public float moveSpeed = 3f;        // Speed at which the enemy moves
    private bool playerInRange = false; // Flag to check if player is in range
    private bool movingToPointA = true; // Flag to check patrol direction
    private Vector3 targetPosition;     // Current patrol target position

    void Start()
    {
        // Start by patrolling to point A
        targetPosition = pointA.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player entered the trigger area
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            // Start chasing the player
            targetPosition = player.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player exited the trigger area
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            // Return to patrolling
            targetPosition = movingToPointA ? pointA.position : pointB.position;
        }
    }

    void Update()
    {
        // Move towards the current target position
        if (playerInRange)
        {
            // If the player is in range, chase the player
            targetPosition = player.position;
        }
        else
        {
            // Otherwise, patrol between points A and B
            Patrol();
        }

        // Move the enemy towards the target position (player or patrol point)
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Optionally: Rotate to face the target position
        RotateToTarget();
    }

    void Patrol()
    {
        // If the enemy has reached the current patrol point, toggle the target between points A and B
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            movingToPointA = !movingToPointA;
            targetPosition = movingToPointA ? pointA.position : pointB.position;
        }
    }

    void RotateToTarget()
    {
        // Calculate the direction to the target position
        Vector3 direction = (targetPosition - transform.position).normalized;

        // Rotate smoothly to face the target position
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }
}
