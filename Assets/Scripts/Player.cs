using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Rigidbody2D rigidBodyPlayer;
	private bool shouldChangeGravity = false;

	private void Update()
	{
		if (getJumpMovement() && !shouldChangeGravity)
		{
			shouldChangeGravity = true;
		}
	}

	private void FixedUpdate()
	{
		if (shouldChangeGravity)
		{
			changeGravity();
		}
	}

	void changeGravity()
	{
		resetVelocity();
		invertGravity();
		shouldChangeGravity = false;
	}

	void invertGravity()
	{
		rigidBodyPlayer.gravityScale *= -1;
	}

	void resetVelocity()
	{
		rigidBodyPlayer.velocity = Vector2.down * 0f;
	}

	bool getJumpMovement()
	{
		return Input.GetKeyDown(KeyCode.Space);
	}
}
