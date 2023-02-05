using System;
using UnityEngine;

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
		private bool _runPressed = false;

		private void Start() {
			SubscribeEvents();

			GameManager.Instance.OnShakeStatusChanged += OnShakeStatusChanged;
		}

		void Update() {
			// The mini-game is active --> Do not allow to move the Character
			if (GameManager.Instance.IsShaking || 
			    GameManager.Instance.IsGameOver || 
			    UIDiary.Instance.IsOpened || 
			    UIGameOver.Instance.IsGameOver) 
				return;

			// Set animator values
			SetAnimationValues();

			// Check movement inputs
			DoMovement();
			// Check rotation inputs
			DoRotation();
		}

		/// <summary>
		/// Subscribes to all required events.
		/// </summary>
		private void SubscribeEvents() {
			CharacterInputs characterInputs = new();
			characterInputs.Character.Enable();

			// Movement
			characterInputs.Character.Forward.performed += (context) => _forwardPressed = true;
			characterInputs.Character.Forward.canceled += (context) => _forwardPressed = false;

			characterInputs.Character.Backwards.performed += (context) => _backwardsPressed = true;
			characterInputs.Character.Backwards.canceled += (context) => _backwardsPressed = false;

			// Rotation
			characterInputs.Character.Left.performed += (context) => _leftPressed = true;
			characterInputs.Character.Left.canceled += (context) => _leftPressed = false;

			characterInputs.Character.Right.performed += (context) => _rightPressed = true;
			characterInputs.Character.Right.canceled += (context) => _rightPressed = false;

			// Run
			characterInputs.Character.Run.performed += (context) => _runPressed = true;
			characterInputs.Character.Run.canceled += (context) => _runPressed = false;
		}

		/// <summary>
		/// Checks if any movement key is pressed and assings the moement values to the object.
		/// </summary>
		private void DoMovement() {
			if (IsWalkingForward()) {
				gameObject.transform.position += gameObject.transform.forward * (CurrentSpeed() * Time.deltaTime);
			} else if (IsWalkingBackwards()) {
				gameObject.transform.position += gameObject.transform.forward * (-CurrentSpeed() * Time.deltaTime);
			}
		}

		/// <summary>
		/// Checks if any rotation key is pressed and assings the moement values to the object.
		/// </summary>
		private void DoRotation() {
			if (IsRotatingLeft()) {
				gameObject.transform.Rotate(0.0f, -_characterMovementConfiguration.RotationSpeed * Time.deltaTime, 0.0f, Space.Self);
			} else if (IsRotatingRight()) {
				gameObject.transform.Rotate(0.0f, _characterMovementConfiguration.RotationSpeed * Time.deltaTime, 0.0f, Space.Self);
			}
		}

		/// <summary>
		/// Returns the current Character speed, taking into account if is walking or running.
		/// </summary>
		/// <returns>Movement speed.</returns>
		private float CurrentSpeed() {
			float result = 0.0f;

			if (IsWalkingForward()) {
				result = _runPressed
					? _characterMovementConfiguration.MovementSpeed * _characterMovementConfiguration.RunFactor
					: _characterMovementConfiguration.MovementSpeed;
			} else if (IsWalkingBackwards()) {
				result = _characterMovementConfiguration.MovementSpeed * _characterMovementConfiguration.MovementBackwardsFactor;
			}

			return result;
		}

		/// <summary>
		/// Sets all the movement-related animator properties.
		/// </summary>
		private void SetAnimationValues() {
			_animator.SetBool("isWalkingForward", IsWalkingForward());
			_animator.SetBool("isWalkingBackwards", IsWalkingBackwards());
			_animator.SetBool("isRunning", IsRunning());
			_animator.SetBool("isRotatingLeft", !IsMoving() && IsRotatingLeft());
			_animator.SetBool("isRotatingRight", !IsMoving() && IsRotatingRight());
		}

		/// <summary>
		/// Returns whether any movement key is pressed or not.
		/// </summary>
		/// <returns><see langword="true"/> if any movement key is pressed, <see langword="false"/> otherwise.</returns>
		public bool IsMoving() =>
			_forwardPressed || _backwardsPressed;

		/// <summary>
		/// Calculates if the Character is walking forward or not.
		/// </summary>
		/// <remarks>
		/// Walking forward has priority over walking backwards.
		/// </remarks>
		/// <returns><see langword="true"/> if the Character is walking forward, <see langword="false"/> otherwise.</returns>
		public bool IsWalkingForward() =>
			_forwardPressed;

		/// <summary>
		/// Calculates if the Character is walking backwards or not.
		/// </summary>
		/// <remarks>
		/// Walking forward has priority over walking backwards.
		/// </remarks>
		/// <returns><see langword="true"/> if the Character is walking backwards, <see langword="false"/> otherwise.</returns>
		public bool IsWalkingBackwards() =>
			!IsWalkingForward() && _backwardsPressed;

		/// <summary>
		/// Calculates if the Character is moving and the run key is pressed or not.
		/// </summary>
		/// <returns><see langword="true"/> if any movement key is pressed, <see langword="false"/> otherwise.</returns>
		public bool IsRunning() =>
			IsWalkingForward() && _runPressed;

		/// <summary>
		/// Calculates if the Character is rotating left or not.
		/// </summary>
		/// <remarks>
		/// Left rotation has priority over right rotation.
		/// </remarks>
		/// <returns><see langword="true"/> if the Character is rotating left, <see langword="false"/> otherwise.</returns>
		public bool IsRotatingLeft() =>
			_leftPressed;

		/// <summary>
		/// Calculates if the Character is rotating left or not.
		/// </summary>
		/// <remarks>
		/// Left rotation has priority over right rotation.
		/// </remarks>
		/// <returns><see langword="true"/> if the Character is rotating right, <see langword="false"/> otherwise.</returns>
		public bool IsRotatingRight() =>
			!IsRotatingLeft() && _rightPressed;

		/// <summary>
		/// Returns whether any rotation key is pressed or not.
		/// </summary>
		/// <returns><see langword="true"/> if any rotation key is pressed, <see langword="false"/> otherwise.</returns>
		public bool IsRotating() =>
			_leftPressed || _rightPressed;
		
		private void OnShakeStatusChanged(bool obj)
		{
				
		}
	}
}
