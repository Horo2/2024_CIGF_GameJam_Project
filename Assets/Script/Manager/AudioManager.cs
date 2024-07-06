using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    // List of audio clips
    public List<AudioClip> audioClips;

    public AudioSource bgmSource1;
    public AudioSource bgmSource2;

    private AudioSource currentBGM;
    private AudioSource nextBGM;

    public AudioClip bgmClip1;
    public AudioClip bgmClip2;

    private bool isDisabled;
    // Fade in/out duration
    public float fadeDuration = 1.0f;

    private void Awake()
    {
        currentBGM = bgmSource1;
        nextBGM = bgmSource2;

        PlayBGM(bgmClip1, true);
    }

    private void Update()
    {
        isDisabled = PlayerController.GetisDisable();
    }

    public void PlayBGM(AudioClip clip, bool loop)
    {
        AudioSource source = isDisabled ? bgmSource1 : bgmSource2;
        source.clip = clip;
        source.loop = loop;
        source.Play();
    }

    public void ToggleBGM()
    {
        StartCoroutine(FadeOutAndSwitch());
        isDisabled = !isDisabled;
    }

    private IEnumerator FadeOutAndSwitch()
    {
        AudioSource fromSource = currentBGM;
        AudioSource toSource = nextBGM;

        float startVolume = fromSource.volume;
        float startTime = fromSource.time; // Save the current playback time

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            fromSource.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
            yield return null;
        }

        fromSource.Stop();

        toSource.clip = isDisabled ? bgmClip2 : bgmClip1;
        toSource.time = startTime; // Set the new source's time to match the previous source
        toSource.volume = 0; // Start with zero volume to fade in
        toSource.Play();

        // Fade in the new source
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            toSource.volume = Mathf.Lerp(0, startVolume, t / fadeDuration);
            yield return null;
        }

        currentBGM = toSource;
        nextBGM = fromSource;
    }

    public void SetVolume(float volume)
    {
        bgmSource1.volume = volume;
        bgmSource2.volume = volume;
    }

}
