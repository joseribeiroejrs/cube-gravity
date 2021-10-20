using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerArcade : MonoBehaviour
{
	public Rigidbody2D rigidBodyPlayer;
	public GameManagerArcade gameManagerArcade;
	public GameObject explosionPlayer;
	public SpriteRenderer splashImage;
	public float movementSpeed = 500f;

	public Joystick joystick;
	private bool shouldChangeGravity = false;
	private bool isDead = false;

	private void Update()
	{
		if (getJumpMovement() && !shouldChangeGravity)
		{
			setShouldChangeGravity();
		}
	}

	private void FixedUpdate()
	{
		if (shouldChangeGravity && !isDead)
		{
			changeGravity();
		}
		movementHorizontal();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Obstacle"))
		{
			isDead = true;
			showExplosionPlayer();
		}
	}

	public void setShouldChangeGravity()
	{
		shouldChangeGravity = true;
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

	void zeroGravity()
	{
		rigidBodyPlayer.gravityScale = 0;
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
		if (getHorizontalMovement() != 0 && !isDead)
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
		float inputHorizontal = Input.GetAxis("Horizontal");
		if (inputHorizontal != 0)
		{
			return inputHorizontal;
		}
		return joystick.Horizontal;
	}

	void showExplosionPlayer()
	{
		resetVelocity();
		zeroGravity();
		splashImage.enabled = false;
		Instantiate(explosionPlayer, transform);
	}
}
