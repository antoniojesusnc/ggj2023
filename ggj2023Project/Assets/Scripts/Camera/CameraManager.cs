using UnityEngine;

namespace Camera
{
	public class CameraManager : Singleton<CameraManager>
	{
		[SerializeField]
		private CameraController _activeCamera;

		private void Start() {
			_activeCamera.Enable(true);
		}

		/// <summary>
		/// Sets a camera as active, disabling the currently active one.
		/// </summary>
		/// <param name="cameraController">Camera controller managing the camera to be enabled.</param>
		public void SetCamera(CameraController cameraController) {
			// Disable the current active camera
			_activeCamera.Enable(false);
			// Set the received camera as currently active
			_activeCamera = cameraController;
			// Enable the new active camera
			cameraController.Enable(true);
		}
	}
}