using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
	public class CharacterMovement : MonoBehaviour
	{
		[SerializeField]
		private float _movementSpeed = 5f;

		[SerializeField]
		private float _rotationSpeed = 5f;

		private bool _forwardPressed = false;
		private bool _backwardsPressed = false;
		private bool _leftPressed = false;
		private bool _rightPressed = false;

		private void Start() {
			CharacterInputs characterInputs = new();
			characterInputs.Character.Enable();
			characterInputs.Character.Forward.performed += OnForwardPressed;
			characterInputs.Character.Forward.canceled += OnForwardReleased;
			characterInputs.Character.Backwards.performed += OnBackwardsPressed;
			characterInputs.Character.Backwards.canceled += OnBackwardsReleased;
			characterInputs.Character.Left.performed += OnLeftPressed;
			characterInputs.Character.Left.canceled += OnLeftReleased;
			characterInputs.Character.Right.performed += OnRightPressed;
			characterInputs.Character.Right.canceled += OnRightReleased;
		}

		private void OnForwardPressed(InputAction.CallbackContext context) => _forwardPressed = true;
		private void OnForwardReleased(InputAction.CallbackContext context) => _forwardPressed = false;

		private void OnBackwardsPressed(InputAction.CallbackContext context) => _backwardsPressed = true;
		private void OnBackwardsReleased(InputAction.CallbackContext context) => _backwardsPressed = false;

		private void OnLeftPressed(InputAction.CallbackContext context) => _leftPressed = true;
		private void OnLeftReleased(InputAction.CallbackContext context) => _leftPressed = false;

		private void OnRightPressed(InputAction.CallbackContext context) => _rightPressed = true;
		private void OnRightReleased(InputAction.CallbackContext context) => _rightPressed = false;

		void FixedUpdate() {
			if (GameManager.Instance.IsShaking)
			{
				return;
			}
			
			// Movement
			if (_forwardPressed) {
				gameObject.transform.position += gameObject.transform.forward * _movementSpeed * Time.deltaTime;
			} else if (_backwardsPressed) {
				gameObject.transform.position += gameObject.transform.forward * -_movementSpeed * Time.deltaTime;
			}

			// Rotation
			if (_leftPressed) {
				gameObject.transform.Rotate(0.0f, -_rotationSpeed * Time.deltaTime, 0.0f, Space.Self);
			} else if (_rightPressed) {
				gameObject.transform.Rotate(0.0f, _rotationSpeed * Time.deltaTime, 0.0f, Space.Self);
			}
		}
	}
}
