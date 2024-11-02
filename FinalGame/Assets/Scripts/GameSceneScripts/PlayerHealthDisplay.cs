using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour
{
    public PlayerHealth playerHealth;  // Reference to the PlayerHealth script
    public Text healthText;            // Reference to the UI Text component

    private void Update()
    {
        // Update the health text with the player's current health
        healthText.text = "Health: " + playerHealth.GetCurrentHealth();
    }
}
