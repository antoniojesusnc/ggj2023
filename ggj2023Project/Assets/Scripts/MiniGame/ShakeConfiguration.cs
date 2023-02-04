using System.Collections.Generic;
using UnityEngine;

public class ShakeConfiguration : ScriptableObject
{
    [SerializeField]
    private List<ShakeConfigurationInfo> _configurationInfos;
    public ShakeConfigurationInfo GetConfigForIntensity(float instanceIntensity)
    {
        return _configurationInfos[0];
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
    [field: SerializeField] 
    public float RandomBigShakeChance { get; private set; }
    [field: SerializeField]
    public float RandomBigShakeStrengthFactor { get; private set; }

    [field: Header("Jumps"), SerializeField]
    public float JumpDistance { get; private set; }
    [field: SerializeField]
    public float JumpTime { get; private set; }
    [field: SerializeField]
    public float JumpTimeToStartCheck { get; private set; }

}
