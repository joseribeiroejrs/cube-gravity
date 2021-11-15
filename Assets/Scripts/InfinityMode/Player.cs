using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Rigidbody2D rigidBodyPlayer;
	public GameManager gameManager;
	public AudioSource invertGravitySound;
	public AudioSource explosionSound;
	public SpriteRenderer splashImage;

	private bool shouldChangeGravity = false;
	private Color playerColor;
	private bool isFirstTimePlayedInvertGravitySound = true;
	private bool isFirstTimePlayedExplosionSound = true;

	private void Update()
	{
		if (getJumpMovement() && !shouldChangeGravity)
		{
			shouldChangeGravity = true;
		}

		changeSpriteColor();
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
		GameOver();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Obstacle"))
		{

			GameOver();
		}
	}

	public void GameOver() {
		startExplosionSound();
		gameManager.gameOver();
	}

	public void changeGravity()
	{
		resetVelocity();
		invertGravity();
		shouldChangeGravity = false;
		playerInvertGravitySound();
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
		return Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);
	}

	void changeSpriteColor()
	{
		Color DEFAULT_BLUE = new Color(0, 9, 191);
		Color DEFAULT_ORANGE = new Color(191, 9, 0);
		playerColor = rigidBodyPlayer.gravityScale > 0 ? DEFAULT_ORANGE : DEFAULT_BLUE;

		gameObject.GetComponent<Renderer>().material.color = playerColor;
	}

	void playerInvertGravitySound()
	{
		if (isFirstTimePlayedInvertGravitySound)
		{
			invertGravitySound.gameObject.SetActive(true);
			isFirstTimePlayedInvertGravitySound = false;
		}
		else
		{
			invertGravitySound.Play();
		}
	}

	void startExplosionSound()
	{
		if (isFirstTimePlayedExplosionSound)
		{
			explosionSound.gameObject.SetActive(true);
			isFirstTimePlayedExplosionSound = false;
		} else
		{
			explosionSound.Play();
		}
	}
}
