using UnityEngine;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class StarterAssetsInputs : MonoBehaviour
{
    public Vector3 move;
	public bool bend;


#if ENABLE_INPUT_SYSTEM
	public void OnMove(InputValue value)
	{
		MoveInput(value.Get<Vector3>());
	}

	public void OnBend(InputValue value)
	{
		BendInput(value.isPressed);
	}


#endif
	public void MoveInput(Vector3 newMoveDirection)
	{
		move = newMoveDirection;
	}

	public void BendInput(bool newBend)
	{
		bend = newBend;
	}

}
