using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // Required for NavMeshAgent

public class EnemyAITrigger : MonoBehaviour
{
    public Transform player;                // Reference to the player's transform
    public Transform pointA;                // First patrol point
    public Transform pointB;                // Second patrol point
    public float detectionRange = 10f;      // Trigger radius for detection
    public float moveSpeed = 3f;            // Speed at which the enemy moves
    private NavMeshAgent agent;             // Reference to the NavMeshAgent component
    private bool playerInRange = false;     // Flag to check if player is in range
    private bool movingToPointA = true;     // Flag to check patrol direction

    void Start()
    {
        // Initialize NavMeshAgent and set its speed
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;

        // Start patrolling towards point A initially
        agent.SetDestination(pointA.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player entered the trigger area
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            agent.SetDestination(player.position); // Start chasing the player
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player exited the trigger area
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Patrol(); // Resume patrolling between points A and B
        }
    }

    void Update()
    {
        if (playerInRange)
        {
            // Continuously update destination to follow player if in range
            agent.SetDestination(player.position);
        }
        else
        {
            // Continue patrolling if player is not in range
            if (!agent.pathPending && agent.remainingDistance < 0.1f)
            {
                // Switch target between point A and B
                Patrol();
            }
        }
    }

    void Patrol()
    {
        // Set the target position based on patrol state
        if (movingToPointA)
        {
            agent.SetDestination(pointA.position);
        }
        else
        {
            agent.SetDestination(pointB.position);
        }

        // Toggle the patrol direction
        movingToPointA = !movingToPointA;
    }
}
