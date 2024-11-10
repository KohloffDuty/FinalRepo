using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float followRange = 10f; // Range within which the enemy will follow the player
    public float rotationSpeed = 5f; // Speed at which the enemy turns towards the player
    public float moveSpeed = 3f; // Speed at which the enemy moves towards the player

    void Update()
    {
        // Check if the player is within range
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= followRange)
        {
            // Turn towards the player
            Vector3 direction = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

            // Move towards the player
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}