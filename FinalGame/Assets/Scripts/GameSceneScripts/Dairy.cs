using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diary : MonoBehaviour
{
    public string diaryContent; // The content of this specific diary

    private DiaryManager diaryManager; // Reference to the DiaryManager

    private void Start()
    {
        // Find the DiaryManager in the scene (you can also manually assign this)
        diaryManager = FindObjectOfType<DiaryManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Show the diary content in the DiaryManager's panel
            if (diaryManager != null)
            {
                diaryManager.ShowDiary(diaryContent);
            }
        }
    }
}

