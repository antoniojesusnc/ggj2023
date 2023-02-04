using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private CameraConfiguration _cameraConfig;

    private bool _isEnabled;

    private Camera _camera;
    private float _originalFov;
    private Quaternion _originalRotation;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        
        GameManager.Instance.OnShakeStatusChanged += OnShakeStatusChanged;
    }

    private void OnShakeStatusChanged(bool shaking)
    {
        if (shaking && !_isEnabled)
        {
            BeginShaker();
        }
        else if (!shaking && _isEnabled)
        {
            StopShaker();
        }
    }

    private void BeginShaker()
    {
        _originalFov = _camera.fieldOfView;
        _originalRotation = _camera.transform.rotation;

        _camera.transform.DOLookAt(GameManager.Instance.Character.HeadTransform.position, _cameraConfig.TimeToBeginShakeLookAt);
        _camera.DOFieldOfView(_cameraConfig.InitialFov, _cameraConfig.TimeToBeginShakeLookAt)
               .onComplete += () => _isEnabled = true;
    }

    private void StopShaker()
    {
        _camera.transform.DORotateQuaternion(_originalRotation, _cameraConfig.TimeToFinishShakeLookAt);
        _camera.DOFieldOfView(_originalFov, _cameraConfig.TimeToFinishShakeLookAt)
               .onComplete += () => _isEnabled = false;
    }

    void Update()
    {
        if (!_isEnabled)
        {
            return;
        }

        ChangeCameraPosAndFov();
    }

    private void ChangeCameraPosAndFov()
    {
        var intensity = GameManager.Instance.Intensity;

        var evaluation = _cameraConfig.Curve.Evaluate(intensity);
        _camera.fieldOfView = Mathf.Lerp(_cameraConfig.InitialFov, _cameraConfig.MaxFov, evaluation);
    }
}
