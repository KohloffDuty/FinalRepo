using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlMenuManager : MonoBehaviour
{
    public GameObject controlMenuPanel; // Reference to the control menu UI panel
    public GameObject gameplayUI;       // Reference to the gameplay UI (HUD, etc.)

    // This function runs when the game starts
    private void Start()
    {
        controlMenuPanel.SetActive(false); // Initially hide the control menu
    }

    // This function runs every frame to check for input
    private void Update()
    {
        // Check if the player presses the Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If the control menu is already open, close it
            if (controlMenuPanel.activeSelf)
            {
                CloseControlMenu();
            }
            // If the control menu is not open, open it
            else
            {
                OpenControlMenu();
            }
        }
    }

    // Function to open the control menu
    public void OpenControlMenu()
    {
        controlMenuPanel.SetActive(true);  // Show the control menu panel
        gameplayUI.SetActive(false);       // Optionally hide the gameplay UI
        Time.timeScale = 0f;               // Pause the game
    }

    // Function to close the control menu
    public void CloseControlMenu()
    {
        controlMenuPanel.SetActive(false); // Hide the control menu panel
        gameplayUI.SetActive(true);        // Optionally show the gameplay UI
        Time.timeScale = 1f;               // Resume the game
    }
}
