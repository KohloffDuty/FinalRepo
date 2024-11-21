using UnityEngine;

public class BackButton : MonoBehaviour
{
   
    [SerializeField] private GameObject panel;

   
    public void DisablePanel()
    {
        if (panel != null)
        {
            panel.SetActive(false); 
        }
        else
        {
            Debug.LogError("Panel is not assigned in the inspector!");
        }
    }
}
