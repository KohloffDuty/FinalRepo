using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class DiaryManager : MonoBehaviour
{
    public GameObject diaryPanel; 
    public TextMeshProUGUI diaryText; 
    private bool isPanelVisible = false;

   
    public void ShowDiary(string content)
    {
        diaryPanel.SetActive(true); 
        diaryText.text = content; 
        isPanelVisible = true;
    }

   
    public void HideDiary()
    {
        diaryPanel.SetActive(false); 
        isPanelVisible = false;
    }

    private void Update()
    {
        
        if (isPanelVisible && Input.GetKeyDown(KeyCode.Escape))
        {
            HideDiary();
        }
    }
}
