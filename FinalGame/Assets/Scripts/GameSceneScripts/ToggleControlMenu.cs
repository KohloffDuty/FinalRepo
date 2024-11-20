using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleControlMenu : MonoBehaviour
{
    public GameObject controlMenu; // Reference to the control menu Canvas

    void Update()
    {
        // Check if the "C" key is pressed
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Toggle the active state of the control menu
            controlMenu.SetActive(!controlMenu.activeSelf);

            // Pause or resume the game when the menu is toggled
            Time.timeScale = controlMenu.activeSelf ? 0 : 1;
        }
    }
}