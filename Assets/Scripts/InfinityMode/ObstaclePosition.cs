using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePosition : MonoBehaviour
{
	public float rangePositionY = 4f;

	private void Start()
	{
		transform.position = getPositionRespawn();
	}

	private float getRandomPositionY()
	{
		return Random.Range(-rangePositionY, rangePositionY);
	}

	private Vector2 getPositionRespawn()
	{
		return new Vector2(transform.position.x, getRandomPositionY());
	}


}
