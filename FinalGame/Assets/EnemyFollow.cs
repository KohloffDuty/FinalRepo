using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float followRange = 10f; // Range within which the enemy will follow the player
    public float rotationSpeed = 5f; // Speed at which the enemy turns towards the player
    public float moveSpeed = 3f; // Speed at which the enemy moves towards the player
    private bool playerInRange = false; // Flag to check if player is in range

    void Update()
    {
        if (playerInRange)
        {
            // Check if the player is within follow range
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= followRange)
            {
                // Turn towards the player
                Vector3 direction = (player.position - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

                // Move towards the player
                transform.position += direction * moveSpeed * Time.deltaTime;
                Debug.Log("Enemy is following the player. Distance: " + distanceToPlayer);
            }
            else
            {
                Debug.Log("Player is out of follow range. Distance: " + distanceToPlayer);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the enemy collides with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true; // Start following the player
            Debug.Log("Player entered the enemy's range. Following the player.");
        }
        else
        {
            Debug.Log("Enemy collided with something else: " + collision.gameObject.name);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check if the player exits the collision
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false; // Stop following the player
            Debug.Log("Player exited the enemy's range. Stopping the follow.");
        }
        else
        {
            Debug.Log("Enemy exited collision with: " + collision.gameObject.name);
        }
    }
}
