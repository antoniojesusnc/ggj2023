using UnityEngine;
using UnityEngine.Serialization;

namespace Camera
{
	public class CameraManager : Singleton<CameraManager>
	{
		[field: SerializeField]
		public CameraController ActiveCamera { get; set; }

		private void Start() {
			ActiveCamera.Enable(true);

			GameManager.Instance.OnShakeStatusChanged += OnShakeStatusChanged;
		}

		private void OnShakeStatusChanged(bool shaking)
		{
			ActiveCamera.GetComponent<AudioListener>().enabled = !shaking;
		}

		/// <summary>
		/// Sets a camera as active, disabling the currently active one.
		/// </summary>
		/// <param name="cameraController">Camera controller managing the camera to be enabled.</param>
		public void SetCamera(CameraController cameraController) {
			// Disable the current active camera
			ActiveCamera.Enable(false);
			// Set the received camera as currently active
			ActiveCamera = cameraController;
			// Enable the new active camera
			cameraController.Enable(true);
		}
	}
}