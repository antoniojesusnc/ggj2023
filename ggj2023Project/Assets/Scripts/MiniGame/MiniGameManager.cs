using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class MiniGameManager : MonoBehaviour
{
    [FormerlySerializedAs("_shakeConfiguration")]
    [Header("Config")]
    [SerializeField] private ShakeConfiguration _shakeConfig;
    [SerializeField] private MousePointConfiguration _mousePointConfig;

    [Header("Shake Objects")]
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private RectTransform _objetiveRectTransform;
    [SerializeField] private RectTransform _mousePoint;

    private ShakeConfigurationInfo _currentShakeConfig;
    private bool _isEnabled;
    private bool _isShaking;

    void Start()
    {
        GameManager.Instance.OnShakeStatusChanged += OnShakeStatusChanged;

        _canvasGroup.alpha = 0;
    }

    private void OnShakeStatusChanged(bool shaking)
    {
        if (shaking && !_isEnabled)
        {
            BeginShaker();
        }
        else if(!shaking && _isEnabled)
        {
            StopShaker();
        }
    }


    void BeginShaker()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.DOFade(1, _shakeConfig.FadeInTime);
        
        _objetiveRectTransform.anchoredPosition = Vector2.zero;

        _isEnabled = true;
    }
    
    private void StopShaker()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.DOFade(0, _shakeConfig.FadeInTime);
        
        _isEnabled = false;
    }

    void Update()
    {
        if (!_isEnabled)
        {
            return;
        }
        
        _mousePoint.position = Input.mousePosition;
        
        _currentShakeConfig = _shakeConfig.GetConfigForIntensity(GameManager.Instance.Intensity);
        
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            var jump = Random.insideUnitCircle * (_currentShakeConfig.JumpDistance * 0.5f);
            _objetiveRectTransform.DOLocalMoveX(
                _currentShakeConfig.JumpDistance * 0.5f + jump.x, _currentShakeConfig.JumpTime);
            _objetiveRectTransform.DOLocalMoveY(
                _currentShakeConfig.JumpDistance * 0.5f + jump.y, _currentShakeConfig.JumpTime);
        }


        if (!_isShaking)
        {
            Shake();
        }

        CheckCollisions();
    }
    private void Shake()
    {
        _isShaking = true;

        var shake = Random.value <= _currentShakeConfig.RandomBigShakeChance
            ? _currentShakeConfig.Strength * _currentShakeConfig.RandomBigShakeStrengthFactor
            : _currentShakeConfig.Strength;
        
        _objetiveRectTransform.DOShakePosition(_currentShakeConfig.Duration,
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
            IncreaseSize();
        }
        else
        {
            DecreaseSize();
        }
    }

    private void IncreaseSize()
    {
        var currentSize = _mousePoint.sizeDelta.x;
        if (currentSize >= _mousePointConfig.MaxSize)
        {
            _mousePoint.sizeDelta = Vector2.one * _mousePointConfig.MaxSize;
            return;
        }

        currentSize += _mousePointConfig.IncreaseFactorPerSecond * Time.deltaTime;
        _mousePoint.sizeDelta = Vector2.one * currentSize;
    }

    private void DecreaseSize()
    {
        var currentSize = _mousePoint.sizeDelta.x;
        currentSize -= _mousePointConfig.DecreaseFactorPerSecond * Time.deltaTime;
        _mousePoint.sizeDelta = Vector2.one * currentSize;
        
        if (currentSize < _mousePointConfig.MinSize)
        {
            GameManager.Instance.GameOver();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(0.5f*_objetiveRectTransform.transform.position, _objetiveRectTransform.lossyScale.x*_objetiveRectTransform.sizeDelta.x);
        
        Gizmos.DrawSphere(0.5f*_mousePoint.transform.position, _mousePoint.lossyScale.x*_mousePoint.sizeDelta.x);
    }
}
