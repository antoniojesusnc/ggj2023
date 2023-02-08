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
    
    private void OnDrawGizmos() {
        DrawGizmosUtil.Draw(Color.red, transform);
        
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_spawnPoint.position, 0.5f);
        Gizmos.DrawLine(transform.position, _spawnPoint.position);
        
    }
}
