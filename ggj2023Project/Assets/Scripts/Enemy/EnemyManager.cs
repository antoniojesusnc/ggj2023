using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField] 
    private EnemyController _enemyControllerPrefab;
    
    public void InitEncounter(EnemyEncounterConfiguration enemyEncounterConfig)
    {
        SpawnEnemy(enemyEncounterConfig);
        
        GameManager.Instance.BeginShaker(enemyEncounterConfig);
    }

    private void SpawnEnemy(EnemyEncounterConfiguration enemyEncounterConfig)
    {
        var enemyController = Instantiate(_enemyControllerPrefab, transform);
        enemyController.SetEncounter(enemyEncounterConfig);
    }
}
