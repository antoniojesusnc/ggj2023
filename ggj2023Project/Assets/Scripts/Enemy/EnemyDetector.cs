using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EnemyDetector : MonoBehaviour
{
    [field: SerializeField] 
    public EnemyEncounterConfiguration EnemyEncounterConfig { get; private set; }
    
    [field: SerializeField] 
    public Transform _spawnPoint { get; private set; }
    
    private void OnTriggerEnter()
    {
        EnemyManager.Instance.InitEncounter(EnemyEncounterConfig, _spawnPoint);
        Destroy(gameObject);
    }
}
