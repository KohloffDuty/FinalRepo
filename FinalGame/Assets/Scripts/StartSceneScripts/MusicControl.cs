using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour

{
    public AudioSource musicSource;
    public float fadeDuration = 2.0f; // Duration for the fade effect

    void Start()
    {
        StartCoroutine(FadeInMusic());
    }

    public IEnumerator FadeInMusic()
    {
        float volume = 0;
        musicSource.volume = 0;  // Start with volume at 0
        musicSource.Play();

        while (volume < 1)
        {
            volume += Time.deltaTime / fadeDuration;
            musicSource.volume = Mathf.Clamp01(volume);  // Increment volume
            yield return null;
        }
    }

    public IEnumerator FadeOutMusic()
    {
        float volume = musicSource.volume;

        while (volume > 0)
        {
            volume -= Time.deltaTime / fadeDuration;
            musicSource.volume = Mathf.Clamp01(volume);  // Decrement volume
            yield return null;
        }

        musicSource.Stop();  // Stop music after fading out
    }
}


