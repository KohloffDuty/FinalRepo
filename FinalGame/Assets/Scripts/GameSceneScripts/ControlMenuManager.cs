using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenuManager : MonoBehaviour
{
    public void BackToMainMenu()
    {
        // Load the main menu scene
        SceneManager.LoadScene("MainMenu");
    }
}
