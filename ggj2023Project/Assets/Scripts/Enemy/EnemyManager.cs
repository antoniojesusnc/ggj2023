using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField] 
    private EnemyController _enemyControllerPrefab;
    
    public void InitEncounter(EnemyEncounterConfiguration enemyEncounterConfig, Transform spawnPoint)
    {
        SpawnEnemy(enemyEncounterConfig, spawnPoint);
    }

    private void SpawnEnemy(EnemyEncounterConfiguration enemyEncounterConfig, Transform spawnPoint)
    {
        var enemyController = Instantiate(_enemyControllerPrefab, spawnPoint.position, Quaternion.identity, transform);
        enemyController.SetEncounter(enemyEncounterConfig);
    }
}
