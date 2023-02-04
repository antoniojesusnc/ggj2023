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
			CharacterItemInteractionInput characterInputs = new();
			characterInputs.ItemInteract.Enable();
			characterInputs.ItemInteract.Interact.performed += OnInteract;
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
