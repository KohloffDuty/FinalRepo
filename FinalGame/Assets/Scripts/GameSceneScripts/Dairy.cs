using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diary : MonoBehaviour
{
    public string diaryContent; 

    private DiaryManager diaryManager; 
    private void Start()
    {
       
        diaryManager = FindObjectOfType<DiaryManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            if (diaryManager != null)
            {
                diaryManager.ShowDiary(diaryContent);
            }
        }
    }
}

