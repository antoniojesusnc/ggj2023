using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIConfiguration : ScriptableObject
{
    [field: SerializeField]
    public float GameOverFadeTime { get; private set; }

    [field: SerializeField]
    public float CharactersPerSecondsInfo { get; private set; }
    
    [field: SerializeField]
    public float CharactersPerSeconds { get; private set; }

    [field: SerializeField]
    public float DelayRemoveInfoText { get; private set; }
    
    [field: Header("Furnitures"), SerializeField]
    public float OpenDoorDelay { get; private set; }
}
