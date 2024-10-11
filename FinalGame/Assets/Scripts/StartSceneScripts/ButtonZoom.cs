using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonZoom : MonoBehaviour
{
    public Vector3 zoomScale = new Vector3(1.2f, 1.2f, 1.2f); // Target scale for zoom in
    public float zoomSpeed = 0.1f; // Speed of the zoom

    private Vector3 originalScale;

    void Start()
    {
        // Store the original scale of the button
        originalScale = transform.localScale;
    }

    // Method to zoom in (scale up) when hovered
    public void ZoomIn()
    {
        StopAllCoroutines(); // Stop any running scale coroutines
        StartCoroutine(ScaleButton(zoomScale));
    }

    // Method to zoom out (scale down) when hover ends
    public void ZoomOut()
    {
        StopAllCoroutines(); // Stop any running scale coroutines
        StartCoroutine(ScaleButton(originalScale));
    }

    // Coroutine to smoothly scale the button
    IEnumerator ScaleButton(Vector3 targetScale)
    {
        while (Vector3.Distance(transform.localScale, targetScale) > 0.01f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, zoomSpeed);
            yield return null; // Wait for the next frame
        }
        transform.localScale = targetScale; // Ensure the final size is set correctly
    }
}

