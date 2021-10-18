using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArcade : MonoBehaviour
{
	public Rigidbody2D rigidBodyPlayer;
	public GameManagerArcade gameManagerArcade;
	public float movementSpeed = 2f;
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
		movementHorizontal();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		gameManagerArcade.gameOver();
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


	void movementHorizontal()
	{
		if (getHorizontalMovement() != 0)
		{
			float movement = getHorizontalMovement() * Time.fixedDeltaTime * movementSpeed;
			rigidBodyPlayer.velocity =new Vector2(movement, rigidBodyPlayer.velocity.y);
		} else
		{
			rigidBodyPlayer.velocity = new Vector2(0, rigidBodyPlayer.velocity.y);
		}
	}

	float getHorizontalMovement()
	{
		return Input.GetAxis("Horizontal");
	}
}
