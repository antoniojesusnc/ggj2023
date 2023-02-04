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
        float characters = 0f;
        while (index < description.Length)
        {
            _text.SetText(description.Substring(0, index));
            
            characters += _uiConfig.CharactersPerSeconds * Time.deltaTime;
            index = Mathf.Clamp((int)characters, 0, description.Length+1);
            yield return 0;
        }
        
        _text.SetText(description);
        
        OnFinishText?.Invoke();
    }
    
    private void OnDisable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }
}
