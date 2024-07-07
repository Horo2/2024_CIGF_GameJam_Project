using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{

    public AudioSource bgmSource1;
    public AudioSource bgmSource2;
    public AudioSource bgmSource3;
    public AudioClip bgmClip1;
    public AudioClip bgmClip2;
    public AudioClip bgmClip3;

    public void Start()
    {
        bgmSource1.clip = bgmClip1;
        bgmSource2.clip = bgmClip2;
        StartCoroutine(PlayBgm1());
        PlayBGM(bgmSource1);
        PlayBGM(bgmSource2);
    }

    public void Update()
    {
        PlayBGM(bgmSource1);
        PlayBGM(bgmSource2);
    }
    public void PlayBGM(AudioSource audioSource)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopPlaying(AudioSource audioSource)
    {
        audioSource.Stop();
    }

    public void PauseBGM(AudioSource audioSource)
    {
        audioSource.Pause();
    }

    public void UnpauseBGM(AudioSource audioSource)
    {
        audioSource.UnPause();
    }

    public void HandoffBGM()
    {
        if(PlayerController.GetisDisable())
        {
            StartCoroutine(PlayBgm1());
        }
        else
        {
            StartCoroutine(PlayBgm2());
        }
    }

    public void PlayPalyerDie()
    {
        bgmSource3.PlayOneShot(bgmClip3,1);
    }
    IEnumerator PlayBgm1()
    {
        // µ≠»Î
        while (bgmSource1.volume < 1f)
        {
            bgmSource1.volume += Time.deltaTime / 2f;
            bgmSource2.volume -= Time.deltaTime / 2f;
            yield return null;
        }
    }
    
    IEnumerator PlayBgm2()
    {
        // µ≠»Î
        while (bgmSource2.volume < 1f)
        {
            bgmSource1.volume -= Time.deltaTime / 2f;
            bgmSource2.volume += Time.deltaTime / 2f;
            yield return null;
        }
    }
}
