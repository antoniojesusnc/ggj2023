using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField] private ShakeConfiguration _shakeConfiguration;
    [SerializeField] private MousePointConfiguration _mousePointConfiguration;

    [SerializeField] private RectTransform _objetiveRectTransform;
    [SerializeField] private RectTransform _mousePoint;

    private ShakeConfigurationInfo _shakeConfig;
    private bool _isEnabled;
    private bool _isShaking;

    void Start()
    {
        _objetiveRectTransform.anchoredPosition = Vector2.zero;

        _isEnabled = true;
    }

    void Update()
    {
        _mousePoint.position = Input.mousePosition;
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            var jump = Random.insideUnitCircle * _shakeConfig.JumpDistance * 0.5f;
            _objetiveRectTransform.DOLocalMoveX(
                _shakeConfig.JumpDistance * 0.5f + jump.x, _shakeConfig.JumpTime);
            _objetiveRectTransform.DOLocalMoveY(
                _shakeConfig.JumpDistance * 0.5f + jump.y, _shakeConfig.JumpTime);
        }

        _shakeConfig = _shakeConfiguration.GetConfigForIntensity(GameManager.Instance.Intensity);

        if (!_isShaking)
        {
            Shake();
        }

        CheckCollisions();
    }
    private void Shake()
    {
        _isShaking = true;

        var shake = Random.value <= _shakeConfig.RandomBigShakeChance
            ? _shakeConfig.Strength * _shakeConfig.RandomBigShakeStrengthFactor
            : _shakeConfig.Strength;
        
        _objetiveRectTransform.DOShakePosition(_shakeConfig.Duration,
                                               shake,
                                               1,
                                               1,
                                               true,
                                               true,
                                               ShakeRandomnessMode.Full).onComplete +=
            () => _isShaking = false;
    }
    
    private void CheckCollisions()
    {
        var distance = (_objetiveRectTransform.transform.position - _mousePoint.transform.position).magnitude;
        if (distance <= 0.5f*_objetiveRectTransform.lossyScale.x*_objetiveRectTransform.sizeDelta.x 
            + 0.5f*_mousePoint.sizeDelta.x *_mousePoint.lossyScale.x)
        {
            Debug.Log("Dentro");
        }
        else
        {
            Debug.Log("Fuera");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(0.5f*_objetiveRectTransform.transform.position, _objetiveRectTransform.lossyScale.x*_objetiveRectTransform.sizeDelta.x);
        
        Gizmos.DrawSphere(0.5f*_mousePoint.transform.position, _mousePoint.lossyScale.x*_mousePoint.sizeDelta.x);
    }
}
