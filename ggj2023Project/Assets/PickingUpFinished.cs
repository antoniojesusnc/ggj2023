using UnityEngine;

public class PickingUp : StateMachineBehaviour
{
	public delegate void PickedUp();
	public static event PickedUp OnPickedUp;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		Debug.Log("Picked up");
		// Set animator property
        animator.SetBool("isPickingUp", false);

		// Invoke end picking up event
		OnPickedUp?.Invoke();
	}
}
