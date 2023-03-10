using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GameManager : Singleton<GameManager>
{
    [field: SerializeField, Range(0,1)]
    public bool IsShaking { get; private set; }
    
    [field: SerializeField, Range(0,1)]
    public float Intensity { get; private set; }

    [field: SerializeField]
    public CharacterManager _character { get; private set; }

    public CharacterManager Character
    {
        get
        {
            if (_character == null)
            {
                _character = GameObject.FindObjectOfType<CharacterManager>();
            }

            return _character;
        }
    }

    public bool IsGameOver { get; private set; }

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

            yield return 0;
        }
    }


    [ContextMenu("FinishShaker")]
    public void FinishShaker()
    {
        IsShaking = false;
        OnShakeStatusChanged?.Invoke(false);
    }

   

    public void PlayAgain()
    {
        IsGameOver = false;
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
        itemToInteract.Interact();
    }

    public void GameOverSuccess()
    {
        IsGameOver = true;
    }
}
