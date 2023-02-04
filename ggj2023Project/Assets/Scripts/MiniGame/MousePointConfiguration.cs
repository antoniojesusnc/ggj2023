using UnityEngine;

public class MousePointConfiguration : ScriptableObject
{
    [field: SerializeField]
    public float Speed { get; private set; }
    
    [field: SerializeField]
    public float MinSize { get; private set; }
    [field: SerializeField]
    public float DecreaseFactorPerSecond { get; private set; }
    [field: SerializeField]
    public float MaxSize { get; private set; }
    [field: SerializeField]
    public float IncreaseFactorPerSecond { get; private set; }
}
