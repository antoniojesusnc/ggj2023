using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
	public class CharacterMovement : MonoBehaviour
	{
		[SerializeField]
		private CharacterMovementConfiguration _characterMovementConfiguration;
		
		[SerializeField]
		private Animator _animator;

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

			_animator.SetBool("isWalking", IsMoving());

			// Movement
			if (_forwardPressed) {
				gameObject.transform.position += gameObject.transform.forward * _characterMovementConfiguration.MovementSpeed * Time.deltaTime;
			} else if (_backwardsPressed) {
				gameObject.transform.position += gameObject.transform.forward * -_characterMovementConfiguration.MovementSpeed * Time.deltaTime;
			}

			// Rotation
			if (_leftPressed) {
				gameObject.transform.Rotate(0.0f, -_characterMovementConfiguration.RotationSpeed * Time.deltaTime, 0.0f, Space.Self);
			} else if (_rightPressed) {
				gameObject.transform.Rotate(0.0f, _characterMovementConfiguration.RotationSpeed * Time.deltaTime, 0.0f, Space.Self);
			}
		}

		public bool IsMoving() =>
			_forwardPressed || _backwardsPressed;
	}
}
