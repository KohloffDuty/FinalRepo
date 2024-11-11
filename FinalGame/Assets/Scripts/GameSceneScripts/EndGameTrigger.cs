using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameTrigger : MonoBehaviour
{
    public string endSceneName = "EndGameScene"; // Name of your end game scene
    public GameObject destructionEffect; // Optional particle effect prefab for alien UFO destruction
    public AudioClip destructionSound;   // Optional sound effect for alien UFO destruction
    private AudioSource audioSource;

    private void Start()
    {
        // Set up the AudioSource if a destruction sound is provided
        if (destructionSound != null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = destructionSound;
        }
    }

    // Detect when the player reaches the watch tower
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player triggered the alien UFO's collider
        if (other.CompareTag("Player"))
        {
            DestroyWatchTower(); // Call method to destroy tower and end game
        }
    }

    // Method to destroy the tower and load the end game scene
    void DestroyWatchTower()
    {
        // Play destruction sound if available
        if (audioSource != null && destructionSound != null)
        {
            audioSource.Play();
        }

        // Instantiate the particle effect if available
        if (destructionEffect != null)
        {
            Instantiate(destructionEffect, transform.position, Quaternion.identity);
        }

        // Destroy this GameObject (watchtower)
        Destroy(gameObject);

        // Transition to the end game scene after a short delay for effects
        SceneManager.LoadScene(endSceneName);
    }
}
