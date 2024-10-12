using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Required if you're using TextMeshPro
using UnityEngine.UI; // Required for UI elements like Button

public class DiaryManager : MonoBehaviour
{
    public GameObject diaryPanel; // The UI Panel that will pop up
    public TextMeshProUGUI diaryText; // The Text component in the UI Panel to display diary content
    public Button closeButton; // Reference to the close button

    private void Start()
    {
        // Assign the ClosePanel function to the button's onClick event
        closeButton.onClick.AddListener(HideDiary);

        // Make sure the panel is hidden at the start of the game
        diaryPanel.SetActive(false);
    }

    // Function to display the diary with specific content
    public void ShowDiary(string content)
    {
        diaryPanel.SetActive(true); // Show the panel
        diaryText.text = content; // Update the text with diary content
    }

    // Function to hide the diary panel
    public void HideDiary()
    {
        diaryPanel.SetActive(false); // Hide the panel
    }
}
