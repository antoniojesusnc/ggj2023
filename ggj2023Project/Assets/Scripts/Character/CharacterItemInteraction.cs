using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
	public class CharacterItemInteraction : MonoBehaviour
	{
		[SerializeField]
		private CharacterMovementConfiguration CharacterMovementConfiguration;

		[SerializeField]
		private Animator _animator;

		private ItemDetector _itemToInteract;

		private CharacterInputs _characterInputs;
		
		private void Start() {
			SubscribeEvents();
		}

		/// <summary>
		/// Subscribes to all required events.
		/// </summary>
		private void SubscribeEvents() {
			_characterInputs = new();
			_characterInputs.Character.Enable();

			_characterInputs.Character.Interact.performed += OnInteract;

			PickingUp.OnPickedUp += OnPickedUp;
		}

		private void OnDestroy()
		{
			PickingUp.OnPickedUp -= OnPickedUp;
		}

		private void OnInteract(InputAction.CallbackContext context)
		{
			if (_itemToInteract == null)
			{
				return;
			}

			// Start Picking up animation
			_animator.SetBool("isPickingUp", true);
		}

		private void OnPickedUp() {
			GameManager.Instance.OpenItem(_itemToInteract);
			_itemToInteract = null;
			
			GameManager.Instance.Character.InTrigger(null);
			UITriggerInput.Instance.ShowSpace(false);
		}

		public void SetTrigger(ItemDetector itemDetector)
		{
			_itemToInteract = itemDetector;
		}
	}
}
