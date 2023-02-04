using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIConfiguration : ScriptableObject
{
    [field: SerializeField]
    public float GameOverFadeTime { get; private set; }

    [field: SerializeField]
    public int CharactersPerFrame { get; private set; }

    [field: SerializeField]
    public float DelayRemoveInfoText { get; private set; }
}
