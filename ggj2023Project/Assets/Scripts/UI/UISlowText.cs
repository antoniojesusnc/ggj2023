using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UISlowText : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI _text;
    
    [SerializeField] 
    private UIConfiguration _uiConfig;

    private Coroutine _coroutine;

    public event Action OnFinishText;
    
    public void SetText(string description)
    {
        StartCoroutine(AnimText(description));
    }

    private IEnumerator AnimText(string description)
    {
        int index = 0;
        while (index < description.Length)
        {
            _text.SetText(description.Substring(index));

            index += _uiConfig.CharactersPerFrame;
            yield return 0;
        }
        
        OnFinishText?.Invoke();
    }
    
    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }
}
