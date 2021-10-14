using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float velocity = 8f;
    public Rigidbody2D rigidyBodyObstacle;

	private bool passedOn = false;

	private void Start()
	{
		velocity = velocity + Time.timeSinceLevelLoad / 5;
	}
	private void FixedUpdate()
	{
        rigidyBodyObstacle.position += Vector2.left * velocity * Time.fixedDeltaTime;
	}


	private void OnBecameVisible()
	{
        passedOn = true;
    }

    private void OnBecameInvisible()
	{
		if (passedOn)
		{
            Destroy(gameObject);
		}
	}
}
