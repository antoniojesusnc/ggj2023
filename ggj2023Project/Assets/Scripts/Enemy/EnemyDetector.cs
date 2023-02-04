using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [field: SerializeField] 
    public EnemyEncounterConfiguration EnemyEncounterConfig { get; private set; } 
    private void OnTriggerEnter()
    {
        EnemyManager.Instance.InitEncounter(EnemyEncounterConfig);
        Destroy(gameObject);
    }
}
