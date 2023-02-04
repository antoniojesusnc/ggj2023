using System.Collections.Generic;
using UnityEngine;

public class ShakeConfiguration : ScriptableObject
{
    [field: SerializeField]
    public float FadeInTime { get; private set; }
    [field: SerializeField]
    public float FadeOutTime { get; private set; }
    
    [SerializeField]
    private List<ShakeConfigurationInfo> _configurationInfos;
    public ShakeConfigurationInfo GetConfigForIntensity(float instanceIntensity)
    {
        for (int i = 0; i < _configurationInfos.Count-1; i++)
        {
            if (_configurationInfos[i + 1].IntensityInitial > instanceIntensity)
            {
                return _configurationInfos[i];
            }
        }
        return _configurationInfos[_configurationInfos.Count-1];
    }
}

[System.Serializable]
public class ShakeConfigurationInfo
{
    [field: SerializeField]
    public float IntensityInitial { get; private set; }
    [field: Header("Shakes"), SerializeField]
    public float Duration { get; private set; }
    [field: SerializeField]
    public float Strength { get; private set; }

    [field: Header("Jumps"), SerializeField, Range(0f,1f)]
    public float RandomJumpChance { get; private set; }
    [field: SerializeField] 
    public float JumpDistance { get; private set; }
    [field: SerializeField]
    public float JumpTime { get; private set; }

}
