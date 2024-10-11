using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Required if you're using TextMeshPro

public class DiaryManager : MonoBehaviour
{
    public GameObject diaryPanel; // The UI Panel that will pop up
    public TextMeshProUGUI diaryText; // The Text component in the UI Panel to display diary content

    private bool isPanelVisible = false;

    // Function to display the diary with specific content
    public void ShowDiary(string content)
    {
        diaryPanel.SetActive(true); // Show the panel
        diaryText.text = content; // Update the text with diary content
        isPanelVisible = true;
    }

    // Function to hide the diary panel
    public void HideDiary()
    {
        diaryPanel.SetActive(false); // Hide the panel
        isPanelVisible = false;
    }

    private void Update()
    {
        // Close the panel if the player presses the Escape key (or any key you choose)
        if (isPanelVisible && Input.GetKeyDown(KeyCode.Escape))
        {
            HideDiary();
        }
    }
}
