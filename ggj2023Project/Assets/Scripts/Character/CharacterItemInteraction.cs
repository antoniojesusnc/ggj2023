using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
	public class CharacterItemInteraction : MonoBehaviour
	{
		[SerializeField]
		private CharacterMovementConfiguration CharacterMovementConfiguration;

		private ItemDetector _itemToInteract;

		private void Start() {
			SubscribeEvents();
		}

		/// <summary>
		/// Subscribes to all required events.
		/// </summary>
		private void SubscribeEvents() {
			CharacterInputs characterInputs = new();
			characterInputs.Character.Enable();

			characterInputs.Character.Interact.performed += OnInteract;
		}

		private void OnInteract(InputAction.CallbackContext context)
		{
			if (_itemToInteract == null)
			{
				return;
			}

			GameManager.Instance.OpenItem(_itemToInteract);
		}

		public void SetTrigger(ItemDetector itemDetector)
		{
			_itemToInteract = itemDetector;
		}
	}
}
