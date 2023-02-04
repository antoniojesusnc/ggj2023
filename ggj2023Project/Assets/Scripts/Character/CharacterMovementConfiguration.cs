using UnityEngine;

public class CharacterMovementConfiguration : ScriptableObject
{
	[field: SerializeField]
	public float MovementSpeed { get; private set; } = 2;

	[field: SerializeField]
	public float RotationSpeed { get; private set; } = 60;
}
