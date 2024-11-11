using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;            // Reference to the player's transform
    public float detectionRange = 10f;  // Range within which the enemy can detect the player
    public float moveSpeed = 3f;        // Speed at which the enemy moves
    public Transform pointA;            // First patrol point
    public Transform pointB;            // Second patrol point
    private Vector3 targetPosition;     // Current target position for patrolling
    private bool movingToPointA = true; // Flag to track which point to move towards
    private float initialY;             // Initial Y position to lock movement on Y axis

    void Start()
    {
        // Set the initial target position to point A and lock the Y position
        targetPosition = new Vector3(pointA.position.x, transform.position.y, pointA.position.z);
        initialY = transform.position.y; // Store the initial Y position
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
        // Move towards the current target position on the XZ plane, keeping the Y position locked
        transform.position = Vector3.MoveTowards(
            transform.position,
            new Vector3(targetPosition.x, initialY, targetPosition.z),
            moveSpeed * Time.deltaTime
        );

        // Rotate to face the target position
        FaceTarget(targetPosition);

        // Check if we have reached the target position
        if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z),
                             new Vector3(targetPosition.x, 0, targetPosition.z)) < 0.1f)
        {
            // Switch target position between point A and B, keeping Y position locked
            targetPosition = movingToPointA ?
                new Vector3(pointB.position.x, initialY, pointB.position.z) :
                new Vector3(pointA.position.x, initialY, pointA.position.z);

            movingToPointA = !movingToPointA; // Toggle the flag
        }
    }

    void ChasePlayer()
    {
        // Move towards the player's position on the XZ plane, keeping Y position locked
        Vector3 playerPositionXZ = new Vector3(player.position.x, initialY, player.position.z);
        transform.position = Vector3.MoveTowards(transform.position, playerPositionXZ, moveSpeed * Time.deltaTime);

        // Rotate to face the player's position
        FaceTarget(playerPositionXZ);
    }

    void FaceTarget(Vector3 target)
    {
        // Calculate the direction to the target on the XZ plane
        Vector3 direction = (target - transform.position).normalized;
        direction.y = 0; // Ensure the rotation stays level on the XZ plane

        // Rotate towards the target direction
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }
}
