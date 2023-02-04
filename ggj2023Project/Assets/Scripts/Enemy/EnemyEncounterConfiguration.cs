using UnityEngine;

[CreateAssetMenu(fileName = "NewEncounter", menuName = "ScriptableObjects/CreateEnemyEncounter", order = 1)]
public class EnemyEncounterConfiguration : ScriptableObject
{
    [field: Header("Image"), SerializeField]
    public Sprite Image { get; private set; }
    
    [field: Header("Approximation"), SerializeField]
    public float ApproximationTime { get; private set; }
    
    [field: SerializeField]
    public float FadeTime { get; private set; }
    
    [field: SerializeField]
    public float DetectDistance { get; private set; }

    [field: SerializeField]
    public float Speed { get; private set; }
    
    [field: Header("Encounter"), SerializeField]
    public float EncounterDuration { get; private set; }
    
    [field: SerializeField]
    public float LeavingEncounterDuration { get; private set; }
    
    [field: SerializeField]
    public AnimationCurve IntensityOverTime { get; private set; }
    
    [field: Header("Leaving"), SerializeField]
    public float LeavingTime { get; private set; }
}
