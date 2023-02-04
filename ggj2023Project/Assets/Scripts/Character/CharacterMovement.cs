using System;
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
			SubscribeEvents();
		}

		void Update() {
			// The mini-game is active --> Do not allow to move the Character
			if (GameManager.Instance.IsShaking) return;

			// Set animator values
			SetAnimationValues();

			// Check movement inputs
			CheckMovement();
			// Check rotation inputs
			CheckRotation();
		}

		/// <summary>
		/// Subscribes to all required events.
		/// </summary>
		private void SubscribeEvents() {
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

		/// <summary>
		/// Checks if any movement key is pressed and assings the moement values to the object.
		/// </summary>
		private void CheckMovement() {
			if (_forwardPressed) {
				gameObject.transform.position += gameObject.transform.forward * _characterMovementConfiguration.MovementSpeed * Time.deltaTime;
			} else if (_backwardsPressed) {
				gameObject.transform.position += gameObject.transform.forward * -_characterMovementConfiguration.MovementSpeed * Time.deltaTime;
			}
		}

		/// <summary>
		/// Checks if any rotation key is pressed and assings the moement values to the object.
		/// </summary>
		private void CheckRotation() {
			if (_leftPressed) {
				gameObject.transform.Rotate(0.0f, -_characterMovementConfiguration.RotationSpeed * Time.deltaTime, 0.0f, Space.Self);
			} else if (_rightPressed) {
				gameObject.transform.Rotate(0.0f, _characterMovementConfiguration.RotationSpeed * Time.deltaTime, 0.0f, Space.Self);
			}
		}

		/// <summary>
		/// Sets all the movement-related animator properties.
		/// </summary>
		private void SetAnimationValues() {
			_animator.SetBool("isWalking", IsMoving());
			_animator.SetBool("isRotating", IsRotating());
		}

		/// <summary>
		/// Returns whether any movement key is pressed or not.
		/// </summary>
		/// <returns><see langword="true"/> if any movement key is pressed, <see langword="false"/> otherwise.</returns>
		public bool IsMoving() =>
			_forwardPressed || _backwardsPressed;

		/// <summary>
		/// Returns whether any rotation key is pressed or not.
		/// </summary>
		/// <returns><see langword="true"/> if any rotation key is pressed, <see langword="false"/> otherwise.</returns>
		public bool IsRotating() =>
			_leftPressed || _rightPressed;
	}
}
