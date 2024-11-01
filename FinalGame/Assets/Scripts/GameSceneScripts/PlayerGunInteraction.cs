using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunInteraction : MonoBehaviour
{
    public GameObject gun;  // Reference to the gun object
    public Transform holdingPosition;  // Where the gun will be held
    private bool isNearGun = false;  // Check if the player is near the gun
    private bool holdingGun = false;  // Track if the player is holding the gun

    void Update()
    {
        // Pick up the gun if near and the player presses 'E'
        if (isNearGun && Input.GetKeyDown(KeyCode.E))
        {
            PickUpGun();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Automatically pick up the gun if the player collides with it
        if (collision.gameObject == gun)
        {
            PickUpGun();
        }
    }

    private void PickUpGun()
    {
        holdingGun = true;

        // Disable Rigidbody to stop physics effects
        Rigidbody gunRb = gun.GetComponent<Rigidbody>();
        gunRb.isKinematic = true;

        // Set the gun's position and parent it to the player
        gun.transform.position = holdingPosition.position;
        gun.transform.rotation = holdingPosition.rotation;
        gun.transform.SetParent(holdingPosition);

        Debug.Log("Gun picked up!");
    }

    public void DropGun()
    {
        if (holdingGun)
        {
            holdingGun = false;

            // Detach the gun from the player
            gun.transform.SetParent(null);

            // Re-enable Rigidbody to allow physics
            Rigidbody gunRb = gun.GetComponent<Rigidbody>();
            gunRb.isKinematic = false;

            // Drop the gun slightly forward from the player
            gun.transform.position = transform.position + transform.forward * 1.5f;

            Debug.Log("Gun dropped!");
        }
    }
}
