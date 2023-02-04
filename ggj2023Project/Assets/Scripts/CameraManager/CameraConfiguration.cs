using UnityEngine;

public class CameraConfiguration : ScriptableObject
{
    [field: Header("BeginShaker"), SerializeField]
    public float TimeToBeginShakeLookAt { get; private set; }
    
    [field: SerializeField]
    public float InitialFov { get; private set; }
    
    [field: SerializeField]
    public float MaxFov { get; private set; }
    
    [field: SerializeField]
    public AnimationCurve Curve { get; private set; }
    
    [field: Header("FinishShaker"), SerializeField]
    public float TimeToFinishShakeLookAt { get; private set; }
}
