using UnityEngine;

public class CharacterMovementConfiguration : ScriptableObject
{
	[field: SerializeField]
	public float MovementSpeed { get; private set; } = 2.0f;
	
	[field: SerializeField]
	public float RunFactor { get; private set; } = 2.0f;

	[field: SerializeField]
	public float RotationSpeed { get; private set; } = 60.0f;
}
