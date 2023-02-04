using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public Transform _character;
    
    [field: SerializeField, Range(0,1)]
    public bool IsShaking { get; private set; }
    
    [field: SerializeField, Range(0,1)]
    public float Intensity { get; private set; }

    public Vector3 CharacterPosition => _character.transform.position;

    
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
