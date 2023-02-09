using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] 
    private AudioConfiguration _audioConfig;

    private List<AudioManagerInfo> _audioSourcesInfo = new();

    void Start()
    {
        GameManager.Instance.OnShakeStatusChanged += OnShakeStatusChanged;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnShakeStatusChanged -= OnShakeStatusChanged;
    }

    private void OnShakeStatusChanged(bool shaking)
    {
        if (shaking)
        {
            FinishAudio(AudioTypes.Ambiente01);
            FinishAudio(AudioTypes.Ambiente02);
        }
        else
        {
            PlayAmbienceAudio();
        }
    }

    public void PlayAmbienceAudio()
    {
        var audio = UnityEngine.Random.value < 0.5f ? AudioTypes.Ambiente01 : AudioTypes.Ambiente02;
        PlaySound(audio);
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
        if (!soundConfigInfo.CanPlayTwice)
        {
            if (IsAlreadySound(soundConfigInfo))
            {
                return;
            }
        }
        
        AudioSource audioSource;
        if (parent != transform)
        {
            audioSource = GetAudioSource();
            _audioSourcesInfo.Add( new AudioManagerInfo(soundConfigInfo.AudioType, audioSource));
        }
        else
        {
            audioSource = GetNewAudioSource(parent);
            var managerInfo = new AudioManagerInfo(soundConfigInfo.AudioType, audioSource);
            _audioSourcesInfo.Add( managerInfo);
            StartCoroutine(DestroyAudioSourceAfterCo(managerInfo, soundConfigInfo.AudioClip.length + soundConfigInfo.FadeOut));
        }

        transform.position = transform.position + transform.forward;
        audioSource.clip = soundConfigInfo.AudioClip;
        audioSource.volume = soundConfigInfo.Volume;
        audioSource.Play();
        
    }

    private bool IsAlreadySound(SoundConfigurationInfo soundConfigInfo)
    {
        for (int i = 0; i < _audioSourcesInfo.Count; i++)
        {
            if (_audioSourcesInfo[i].AudioTypes == soundConfigInfo.AudioType &&
                _audioSourcesInfo[i].AudioSource.isPlaying)
            {
                return true;
            }
        }

        return false;
    }

    private IEnumerator DestroyAudioSourceAfterCo(AudioManagerInfo audioSourcesInfo, float audioClipLength)
    {
        yield return new WaitForSeconds(audioClipLength);

        if (audioSourcesInfo == null)
        {
            yield break;
        }

        DestroyAudioSource(audioSourcesInfo);
    }

    private void DestroyAudioSource(AudioManagerInfo audioSourcesInfo)
    {
        if (audioSourcesInfo.AudioSource != null)
        {
            audioSourcesInfo.AudioSource.Stop();
            Destroy(audioSourcesInfo.AudioSource);
        }
        _audioSourcesInfo.Remove(audioSourcesInfo);
        OnDestroySound(audioSourcesInfo.AudioTypes);
    }

    private void OnDestroySound(AudioTypes audioTypes)
    {
        if (GameManager.Instance.IsShaking)
        {
            return;
        }

        if (audioTypes == AudioTypes.Ambiente01
            || audioTypes == AudioTypes.Ambiente02)
        {
            PlayAmbienceAudio();
        }
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
        var audioSourcesInfo =_audioSourcesInfo.Find(audioInfo => audioInfo.AudioTypes == audioToFade);
        if (audioSourcesInfo == null)
        {
            return;
        }


        FadeOut(audioSourcesInfo);
    }

    private void FadeOut(AudioManagerInfo audioSourcesInfo)
    {
        _audioConfig.TryGetSoundConfig(audioSourcesInfo.AudioTypes, out var audioSourcesConfigInfo);

        if (audioSourcesConfigInfo.FadeOut > 0)
        {
            audioSourcesInfo.AudioSource.DOFade(0, audioSourcesConfigInfo.FadeOut);
            StartCoroutine(DestroyAudioSourceAfterCo(audioSourcesInfo, audioSourcesConfigInfo.FadeOut));
        }
        else
        {
            DestroyAudioSource(audioSourcesInfo);
        }
    }

    public float GetDuration(AudioTypes audioType)
    {
        if (!_audioConfig.TryGetSoundConfig(audioType, out var audioSourcesInfo))
        {
            return 0;
        }

        return audioSourcesInfo.AudioClip.length;
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
