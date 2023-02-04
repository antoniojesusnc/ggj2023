using System;
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
    public void BeginShaker()
    {
        IsShaking = true;
        OnShakeStatusChanged?.Invoke(true);
    }
    
    [ContextMenu("FinishShaker")]
    private void FinishShaker()
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
        if (itemToInteract.ItemInfoConfig.Collectable)
        {
            ItemsCollected.Add(itemToInteract.ItemInfoConfig);
            Destroy(itemToInteract.gameObject);
        }
    }
}
