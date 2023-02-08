using System;
using DG.Tweening;
using UnityEngine;

namespace Camera
{
	[RequireComponent(typeof(UnityEngine.Camera))]
	public class CameraController : MonoBehaviour
	{
		[SerializeField]
		private CameraConfiguration _cameraConfig;

		private bool _isShakeEnabled;

		private UnityEngine.Camera _camera;
		private float _originalFov;
		private Quaternion _originalRotation;

		private void Awake() {
			_camera = GetComponent<UnityEngine.Camera>();
			_camera.gameObject.SetActive(false);
		}

		private void Start() {
			GameManager.Instance.OnShakeStatusChanged += OnShakeStatusChanged;
		}

		private void OnShakeStatusChanged(bool shaking) {
			if (shaking && !_isShakeEnabled) {
				BeginShaker();
			} else if (!shaking && _isShakeEnabled) {
				StopShaker();
			}
		}

		public void Enable(bool enable) {
			gameObject.SetActive(enable);
		}

		private void BeginShaker() {
			_originalFov = _camera.fieldOfView;
			_originalRotation = _camera.transform.rotation;

			_camera.transform.DOLookAt(GameManager.Instance.Character.HeadTransform.position, _cameraConfig.TimeToBeginShakeLookAt);
			_camera.DOFieldOfView(_cameraConfig.InitialFov, _cameraConfig.TimeToBeginShakeLookAt)
				   .onComplete += () => _isShakeEnabled = true;
		}

		private void StopShaker() {
			_camera.transform.DORotateQuaternion(_originalRotation, _cameraConfig.TimeToFinishShakeLookAt);
			_camera.DOFieldOfView(_originalFov, _cameraConfig.TimeToFinishShakeLookAt)
				   .onComplete += () => _isShakeEnabled = false;
		}

		void Update() {
			if (!_isShakeEnabled) {
				return;
			}

			ChangeCameraPosAndFov();
		}

		private void ChangeCameraPosAndFov() {
			var intensity = GameManager.Instance.Intensity;

			var evaluation = _cameraConfig.Curve.Evaluate(intensity);
			_camera.fieldOfView = Mathf.Lerp(_cameraConfig.InitialFov, _cameraConfig.MaxFov, evaluation);
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = new Color(1f,1f,0f,0.4f);
			var camera = GetComponent<UnityEngine.Camera>();
			Gizmos.matrix = Matrix4x4.TRS( transform.position, transform.rotation, new Vector3(camera.aspect, 1.0f, 1.0f) );
			for (int i = 0; i < 20; i+=2)
			{
			Gizmos.DrawFrustum(Vector3.zero, 
			                   i, 
			                   5, 
			                   camera.nearClipPlane, 
			                   camera.aspect);
				
			}
		}
	}
}