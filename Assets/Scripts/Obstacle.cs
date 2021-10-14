using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float velocity = 8f;
    public Rigidbody2D rigidyBodyObstacleTop;
    public Rigidbody2D rigidyBodyObstacleBottom;
    public Rigidbody2D rigidyBodyPointsUpdate;

	private bool passedOn = false;

	private void Start()
	{
		velocity = velocity + Time.timeSinceLevelLoad / 5;
	}
	private void FixedUpdate()
	{
		Vector2 positionObstacles = Vector2.left * velocity * Time.fixedDeltaTime;
		rigidyBodyObstacleTop.position += positionObstacles;
		rigidyBodyObstacleBottom.position += positionObstacles;
		rigidyBodyPointsUpdate.position += positionObstacles;
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
