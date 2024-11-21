using UnityEngine;
using TMPro;

public class TutorialPrompt : MonoBehaviour
{
    public TextMeshProUGUI promptText; // Reference to the TextMeshPro element
    public string[] tutorialPrompts;  // Array of tutorial messages
    public float displayTime = 3f;    // Time each prompt is displayed
    public float zoomDuration = 0.5f; // Time for zoom-in and zoom-out animations
    public Vector3 zoomScale = new Vector3(1.2f, 1.2f, 1f); // Zoom-in scale

    private int currentPromptIndex = 0;

    private void Start()
    {
        if (promptText != null)
        {
            // Ensure the text is initially hidden
            promptText.gameObject.SetActive(false);

            if (tutorialPrompts.Length > 0)
            {
                StartCoroutine(DisplayPrompts());
            }
            else
            {
                Debug.LogError("No tutorial prompts are set.");
            }
        }
        else
        {
            Debug.LogError("Prompt text is not assigned.");
        }
    }

    private System.Collections.IEnumerator DisplayPrompts()
    {
        while (currentPromptIndex < tutorialPrompts.Length)
        {
            // Show the text and set the message
            promptText.text = tutorialPrompts[currentPromptIndex];
            promptText.gameObject.SetActive(true);

            // Zoom in
            yield return StartCoroutine(ZoomText(promptText.transform, Vector3.one, zoomScale, zoomDuration));

            // Wait while the text is displayed
            yield return new WaitForSeconds(displayTime);

            // Zoom out
            yield return StartCoroutine(ZoomText(promptText.transform, zoomScale, Vector3.one, zoomDuration));

            // Hide the text
            promptText.gameObject.SetActive(false);

            currentPromptIndex++;
        }

        // Ensure the text is hidden after all prompts
        promptText.gameObject.SetActive(false);
    }

    private System.Collections.IEnumerator ZoomText(Transform textTransform, Vector3 startScale, Vector3 endScale, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            textTransform.localScale = Vector3.Lerp(startScale, endScale, elapsedTime / duration);
            yield return null;
        }

        textTransform.localScale = endScale; 
    }
}
