using UnityEngine;

public class CharacterMovementConfiguration : ScriptableObject
{
	[field: SerializeField]
	public float MovementSpeed { get; private set; } = 2.0f;
	
	[field: SerializeField]
	public float MovementBackwardsFactor { get; private set; } = 0.5f;
	
	[field: SerializeField]
	public float RunFactor { get; private set; } = 2.0f;

	[field: SerializeField]
	public float RotationSpeed { get; private set; } = 60.0f;
	
	[field: Header("Sounds"), SerializeField]
	public float ForwardStepDuration { get; private set; }
	[field: SerializeField]
	public float RunningStepDuration { get; private set; }
	[field: SerializeField]
	public float BackwardStepDuration { get; private set; }
	[field: SerializeField]
	public float RotateStepDuration { get; private set; }
}
