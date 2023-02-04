using UnityEngine;

public class MousePointConfiguration : ScriptableObject
{
    [field: SerializeField]
    public float MinSize { get; private set; }
}
