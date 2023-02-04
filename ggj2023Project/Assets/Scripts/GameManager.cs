using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [field: SerializeField, Range(0,1)]
    public bool IsShaking { get; private set; }
    
    [field: SerializeField, Range(0,1)]
    public float Intensity { get; private set; }

    [field: SerializeField]
    public CharacterController Character { get; private set; }

    
    [field: SerializeField] public event Action<bool> OnShakeStatusChanged;

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
        FinishShaker();
        Debug.Log("GAME OVER");
    }

}
