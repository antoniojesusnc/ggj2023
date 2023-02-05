using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] 
    private AudioConfiguration _audioConfig;

    private List<AudioManagerInfo> _audioSourcesInfo = new();
    
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
        if (!_audioConfig.TryGetSoundConfig(audioType, out var soundConfigInfo))
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
            StartCoroutine(DestroyAudioSourceAfter(audioSource, soundConfigInfo.AudioClip.length + soundConfigInfo.FadeOut));
        }

        transform.position = transform.position + transform.forward;
        audioSource.clip = soundConfigInfo.AudioClip;
        audioSource.volume = soundConfigInfo.Volume;
        audioSource.Play();
        
        _audioSourcesInfo.Add( new AudioManagerInfo(soundConfigInfo.AudioType, audioSource));
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

    public void FinishAudio(AudioTypes audioToFade)
    {
        var audioSource =_audioSourcesInfo.Find(audioInfo => audioInfo.AudioTypes == audioToFade);
        if (audioSource == null)
        {
            return;
        }


        FadeOut(audioToFade, audioSource.AudioSource);
    }

    private void FadeOut(AudioTypes audioToFade, AudioSource audioSource)
    {
        _audioConfig.TryGetSoundConfig(audioToFade, out var _audioSourcesInfo);

        if (_audioSourcesInfo.FadeOut > 0)
        {
            audioSource.DOFade(0, _audioSourcesInfo.FadeOut).onComplete += () => DestroyAudioSourceAfter(audioSource, 0);
        }
        else
        {
            DestroyAudioSourceAfter(audioSource, 0);
        }
    }
}

public class AudioManagerInfo
{
    public AudioTypes AudioTypes { get; private set; }
    public AudioSource AudioSource { get; private set; }

    public AudioManagerInfo(AudioTypes audioTypes, AudioSource audioSource)
    {
        AudioTypes = audioTypes;
        AudioSource = audioSource;
    }
}
