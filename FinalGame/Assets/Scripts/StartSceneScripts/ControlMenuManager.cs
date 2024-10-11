using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMenuManager : MonoBehaviour
{
    public GameObject controlMenuPanel;
    public GameObject gameplayUI;

    private void Start()
    {
        //  Hidden control menu
        controlMenuPanel.SetActive(false);
    }

    public void OpenControlMenu()
    {
        controlMenuPanel.SetActive(true);
        gameplayUI.SetActive(false); // Hide gameplay UI if needed
        Time.timeScale = 0f; // For pausing the game
    }

    public void CloseControlMenu()
    {
        controlMenuPanel.SetActive(false);
        gameplayUI.SetActive(true); 
        Time.timeScale = 1f; // Resume the game
    }
}

