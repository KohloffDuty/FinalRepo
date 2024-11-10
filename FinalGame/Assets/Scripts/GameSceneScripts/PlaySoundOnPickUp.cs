using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnPickup : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component on this GameObject
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with the object
        if (other.CompareTag("Player"))
        {
            // Play the sound
            audioSource.Play();

            // Optional: Disable the item after playing the sound
            gameObject.SetActive(false);
        }
    }
}
