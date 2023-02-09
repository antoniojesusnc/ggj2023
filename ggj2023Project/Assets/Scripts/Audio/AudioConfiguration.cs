using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "ScriptableObjects/SoundConfiguration", order = 1)]
public class AudioConfiguration : ScriptableObject
{
    [field: SerializeField]
    public float AudioDistance { get; private set; }

        [SerializeField]
    private List<SoundConfigurationInfo> _audios = new();
    
    public bool TryGetSoundConfig(AudioTypes audioType, out SoundConfigurationInfo soundConfigInfo)
    {
        soundConfigInfo = _audios.Find(audioInfo => audioInfo.AudioType == audioType);
        return soundConfigInfo != null;
    }
}

[System.Serializable]
public class SoundConfigurationInfo
{
    [field: SerializeField]
    public AudioTypes AudioType { get; private set; }
    
    [field: SerializeField]
    public AudioClip AudioClip { get; private set; }

    [field: SerializeField] 
    public float Volume { get; private set; } = 1;
    
    [field: SerializeField] 
    public float FadeOut { get; private set; }
    
    [field: SerializeField] 
    public bool CanPlayTwice { get; private set; }
}
