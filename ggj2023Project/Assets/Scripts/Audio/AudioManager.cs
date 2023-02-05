using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] 
    private AudioConfiguration audioConfig;

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        var audioSources = GetComponents<AudioSource>();
        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i].Stop();
        }
    }

    public void PlaySound(AudioTypes audioType)
    {
        PlaySound(audioType, transform);
    }

    public void PlaySound(AudioTypes audioType, Transform parent)
    {
        if (!audioConfig.TryGetSoundConfig(audioType, out var soundConfigInfo))
        {
            Debug.LogWarning("Audio not set");
            return;
        }

        PlaySoundInternal(soundConfigInfo, parent);
    }

    private void PlaySoundInternal(SoundConfigurationInfo soundConfigInfo, Transform parent)
    {
        AudioSource audioSource;
        if (parent != transform)
        {
            audioSource = GetAudioSource();
        }
        else
        {
            audioSource = GetNewAudioSource(parent);
            StartCoroutine(DestroyAudioSourceAfter(audioSource, soundConfigInfo.AudioClip.length));
        }

        transform.position = transform.position + transform.forward;
        audioSource.clip = soundConfigInfo.AudioClip;
        audioSource.volume = soundConfigInfo.Volume;
        audioSource.Play();
    }

    private IEnumerator DestroyAudioSourceAfter(AudioSource audioSource, float audioClipLength)
    {
        yield return new WaitForSeconds(audioClipLength);
        Destroy(audioSource);
    }

    private AudioSource GetAudioSource()
    {
        var audioSources = GetComponents<AudioSource>();
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (!audioSources[i].isPlaying)
            {
                return audioSources[i];
            }
        }

        return GetNewAudioSource(transform);
    }

    private AudioSource GetNewAudioSource(Transform parent)
    {
        return parent.gameObject.AddComponent<AudioSource>();
    }
}
