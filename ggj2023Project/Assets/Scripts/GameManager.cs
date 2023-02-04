using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [field: SerializeField, Range(0,1)]
    public bool IsShaking { get; private set; }
    
    [field: SerializeField, Range(0,1)]
    public float Intensity { get; private set; }

    [field: SerializeField]
    public CharacterManager Character { get; private set; }
    
    public bool IsGameOver { get; private set; }
    
    public List<ItemInfoConfiguration> ItemsCollected { get; private set; } = new();
    
    [field: SerializeField] public event Action<bool> OnShakeStatusChanged;
    [field: SerializeField] public event Action OnGameOver;

    [ContextMenu("BeginShaker")]
    public void BeginShaker(EnemyEncounterConfiguration enemyEncounterConfiguration)
    {
        IsShaking = true;
        OnShakeStatusChanged?.Invoke(true);

        StartCoroutine(IncreaseIntensityOverTime(enemyEncounterConfiguration));
    }

    private IEnumerator IncreaseIntensityOverTime(EnemyEncounterConfiguration enemyEncounterConfig)
    {
        float timeStamp = 0;
        while (IsShaking)
        {
            timeStamp += Time.deltaTime;

            Intensity = enemyEncounterConfig.IntensityOverTime.Evaluate(timeStamp / enemyEncounterConfig.EncounterDuration);

            if (timeStamp > enemyEncounterConfig.EncounterDuration)
            {
                FinishShaker();
            }
            
            yield return 0;
        }
    }


    [ContextMenu("FinishShaker")]
    public void FinishShaker()
    {
        IsShaking = false;
        OnShakeStatusChanged?.Invoke(false);
    }
    
    public void GameOver()
    {
        IsGameOver = true;
        FinishShaker();
        OnGameOver?.Invoke();
    }

    public void OpenItem(ItemDetector itemToInteract)
    {
        UIDiary.Instance.OpenItem(itemToInteract.ItemInfoConfig);
        if (itemToInteract.ItemInfoConfig.Collectable && !itemToInteract.IsCollected)
        {
            ItemsCollected.Add(itemToInteract.ItemInfoConfig);
            itemToInteract.Collect();
        }
    }
}
