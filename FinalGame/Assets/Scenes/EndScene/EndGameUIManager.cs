using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameUIManager : MonoBehaviour
{
    public string mainMenuSceneName = "MainMenuScene"; // Set this to your main menu scene name
    public string gameSceneName = "GameScene";         // Set this to your main game scene name

    // Method for replay button
    public void ReplayGame()
    {
        // Reload the current game scene to start a new game
        SceneManager.LoadScene(gameSceneName);
    }

    // Method for main menu button
    public void GoToMainMenu()
    {
        // Load the main menu scene
        SceneManager.LoadScene(mainMenuSceneName);
    }

    // Method for quit button
    public void QuitGame()
    {
        // Quit the application (this works in build, not in editor)
        Application.Quit();
        Debug.Log("Game is quitting..."); // Only shows in editor
    }
}
