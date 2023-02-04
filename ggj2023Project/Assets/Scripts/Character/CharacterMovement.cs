using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
	public class CharacterMovement : MonoBehaviour
	{
		[SerializeField]
		private CharacterMovementConfiguration CharacterMovementConfiguration;

		private bool _forwardPressed = false;
		private bool _backwardsPressed = false;
		private bool _leftPressed = false;
		private bool _rightPressed = false;

		private void Start() {
			CharacterInputs characterInputs = new();
			characterInputs.Character.Enable();

			characterInputs.Character.Forward.performed += (context) => _forwardPressed = true;
			characterInputs.Character.Forward.canceled += (context) => _forwardPressed = false;
			
			characterInputs.Character.Backwards.performed += (context) => _backwardsPressed = true;
			characterInputs.Character.Backwards.canceled += (context) => _backwardsPressed = false;
			
			characterInputs.Character.Left.performed += (context) => _leftPressed = true;
			characterInputs.Character.Left.canceled += (context) => _leftPressed = false;
			
			characterInputs.Character.Right.performed += (context) => _rightPressed = true;
			characterInputs.Character.Right.canceled += (context) => _rightPressed = false;
		}

		void Update() {
			// Do not allow to move the Character while the mini-game is active
			if (GameManager.Instance.IsShaking)
			{
				return;
			}
			
			// Movement
			if (_forwardPressed) {
				gameObject.transform.position += gameObject.transform.forward * CharacterMovementConfiguration.MovementSpeed * Time.deltaTime;
			} else if (_backwardsPressed) {
				gameObject.transform.position += gameObject.transform.forward * -CharacterMovementConfiguration.MovementSpeed * Time.deltaTime;
			}

			// Rotation
			if (_leftPressed) {
				gameObject.transform.Rotate(0.0f, -CharacterMovementConfiguration.RotationSpeed * Time.deltaTime, 0.0f, Space.Self);
			} else if (_rightPressed) {
				gameObject.transform.Rotate(0.0f, CharacterMovementConfiguration.RotationSpeed * Time.deltaTime, 0.0f, Space.Self);
			}
		}
	}
}
