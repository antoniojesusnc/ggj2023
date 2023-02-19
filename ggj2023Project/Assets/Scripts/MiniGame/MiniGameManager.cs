using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MiniGameManager : MonoBehaviour
{
    [FormerlySerializedAs("_shakeConfiguration")] [Header("Config")] [SerializeField]
    private ShakeConfiguration _shakeConfig;

    [SerializeField] private MousePointConfiguration _mousePointConfig;

    [Header("Shake Objects")] [SerializeField]
    private CanvasGroup _canvasGroup;

    [SerializeField] private RectTransform _objetiveRectTransform;
    [SerializeField] private RectTransform _mousePoint;

    private ShakeConfigurationInfo _currentShakeConfig;
    private bool _isShaking;
    private bool _isJumping;

    private bool _leftMovement;
    private bool _rightMovement;
    private bool _upMovement;
    private bool _downMovement;

    float _originalSize;
    
    void Start()
    {
        GameManager.Instance.OnShakeStatusChanged += OnShakeStatusChanged;

        _canvasGroup.alpha = 0;

        SubscribeToInput();

        _originalSize = _mousePoint.sizeDelta.x;
    }

    private void SubscribeToInput()
    {
        MiniGameInputs miniGameInputs = new();
        miniGameInputs.MiniGame.Left.performed += (context) =>  _leftMovement = true;
        miniGameInputs.MiniGame.Left.canceled += (context) =>  _leftMovement = false;
        miniGameInputs.MiniGame.Right.performed += (context) =>  _rightMovement = true;
        miniGameInputs.MiniGame.Right.canceled += (context) =>  _rightMovement = false;
        miniGameInputs.MiniGame.Up.performed += (context) =>  _upMovement = true;
        miniGameInputs.MiniGame.Up.canceled += (context) =>  _upMovement = false;
        miniGameInputs.MiniGame.Down.performed += (context) =>  _downMovement = true;
        miniGameInputs.MiniGame.Down.canceled += (context) =>  _downMovement = false;
        miniGameInputs.Enable();
    }

    private void OnShakeStatusChanged(bool shaking)
    {
        if (shaking)
        {
            BeginShaker();
        }
        else if (!shaking)
        {
            StopShaker();
        }
    }
    
    void BeginShaker()
    {
        _mousePoint.sizeDelta = Vector2.one * _originalSize;
        _canvasGroup.alpha = 0;
        _canvasGroup.DOFade(1, _shakeConfig.FadeInTime);

        _objetiveRectTransform.anchoredPosition = Vector2.zero;
        _mousePoint.anchoredPosition = Vector2.zero;
    }

    private void StopShaker()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.DOFade(0, _shakeConfig.FadeInTime);

        _mousePoint.sizeDelta = Vector2.one * _originalSize;
    }

    void Update()
    {
        if (!GameManager.Instance.IsShaking)
        {
            return;
        }

        MoveMouseInput();

        UpdateShakeOrMovement();

        CheckCollisions();
    }

    private void UpdateShakeOrMovement()
    {
        _currentShakeConfig = _shakeConfig.GetConfigForIntensity(GameManager.Instance.Intensity);

        if (!_isShaking && !_isJumping)
        {
            CheckJump();
            if (!_isJumping)
            {
                Shake();
            }
        }
    }

    private void MoveMouseInput()
    {
        if (_leftMovement)
        {
            _mousePoint.transform.position +=
                Vector3.left * (_mousePointConfig.Speed * _mousePoint.transform.lossyScale.x * Time.deltaTime);
        }

        if (_rightMovement)
        {
            _mousePoint.transform.position +=
                Vector3.right * (_mousePointConfig.Speed * _mousePoint.transform.lossyScale.x * Time.deltaTime);
        }

        if (_upMovement)
        {
            _mousePoint.transform.position +=
                Vector3.up * (_mousePointConfig.Speed * _mousePoint.transform.lossyScale.x * Time.deltaTime);
        }

        if (_downMovement)
        {
            _mousePoint.transform.position +=
                Vector3.down * (_mousePointConfig.Speed * _mousePoint.transform.lossyScale.x * Time.deltaTime);
        }
    }

    private void CheckJump()
    {
        var shouldJump = Random.value <= _currentShakeConfig.RandomJumpChance;
        if (!shouldJump)
        {
            return;
        }

        _isJumping = true;
        var jump = Random.insideUnitCircle * (_currentShakeConfig.JumpDistance * 0.5f);
        _objetiveRectTransform.DOLocalMoveX(
            _currentShakeConfig.JumpDistance * 0.5f + jump.x, _currentShakeConfig.JumpTime);
        _objetiveRectTransform.DOLocalMoveY(
            _currentShakeConfig.JumpDistance * 0.5f + jump.y, _currentShakeConfig.JumpTime)
                              .onComplete += () => _isJumping = false;
    }

    private void Shake()
    {
        _isShaking = true;
        
        _objetiveRectTransform.DOShakePosition(_currentShakeConfig.Duration,
                                               _currentShakeConfig.Strength,
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
