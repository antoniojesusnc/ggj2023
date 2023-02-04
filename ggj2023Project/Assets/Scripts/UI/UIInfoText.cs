using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIInfoText : Singleton<UIInfoText>
{
    [SerializeField]
    private UISlowText _slowText;

    [SerializeField]
    private Canvas _infoCanvas;
    
    [SerializeField]
    private UIConfiguration _uiConfig;

    private Coroutine _coroutine;
    
    void Start()
    {
        _slowText.OnFinishText += OnFinishText;
    }

    private void OnFinishText()
    {
        StartCoroutine(DelayCall(_uiConfig.DelayRemoveInfoText, HideInfo));
    }

    private void HideInfo()
    {
        _infoCanvas.gameObject.SetActive(false);
    }

    private IEnumerator DelayCall(float delayRemoveInfoText, Action delayedCall)
    {
        yield return new WaitForSeconds(delayRemoveInfoText);
        delayedCall?.Invoke();
    }

    public void ShowText(string text)
    {
        StopCoroutine(_coroutine);
        _infoCanvas.gameObject.SetActive(true);
        _slowText.SetText(text);
    }
}
