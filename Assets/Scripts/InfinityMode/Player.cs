using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Rigidbody2D rigidBodyPlayer;
	public GameManager gameManager;
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
		updateGravityScale();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		gameManager.gameOver();
	}

	void changeGravity()
	{
		resetVelocity();
		invertGravity();
		shouldChangeGravity = false;
	}

	void updateGravityScale()
	{
		float incrementGravityScale = Time.timeSinceLevelLoad / 100000;
		if (rigidBodyPlayer.gravityScale > 0)
		{
			rigidBodyPlayer.gravityScale += incrementGravityScale;
		} else
		{
			rigidBodyPlayer.gravityScale -= incrementGravityScale;
		}
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
