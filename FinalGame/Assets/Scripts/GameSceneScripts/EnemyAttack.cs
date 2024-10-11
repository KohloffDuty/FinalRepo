using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform player;           // Reference to the player's position
    public float attackRange = 10f;    // Distance within which the enemy will attack
    public float meleeRange = 2f;      // Distance for melee attacks
    public float attackCooldown = 2f;  // Time between attacks
    public GameObject projectilePrefab;// Projectile to launch
    public Transform firePoint;        // Point where the projectile spawns
    public float projectileSpeed = 10f;// Speed of the projectile
    private float nextAttackTime = 0f;

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange && Time.time >= nextAttackTime)
        {
            if (distanceToPlayer <= meleeRange)
            {
                MeleeAttack();
            }
            else
            {
                RangedAttack();
            }

            nextAttackTime = Time.time + attackCooldown;
        }
    }

    void MeleeAttack()
    {
        // Implement melee attack logic here (e.g., damage player)
        Debug.Log("Enemy performs melee attack!");
        // Optional: Add animations or sound effects here
    }

    void RangedAttack()
    {
        Debug.Log("Enemy performs ranged attack!");

        // Instantiate a projectile and launch it towards the player
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        Vector3 direction = (player.position - firePoint.position).normalized;
        rb.velocity = direction * projectileSpeed;

        // Optional: Add projectile sound or visual effects here
    }

    void OnDrawGizmosSelected()
    {
        // Visualize attack ranges in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, meleeRange);
    }

}
