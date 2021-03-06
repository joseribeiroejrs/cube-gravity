using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public Obstacle obstacle;
	public float intervalToCreateObstacle = 2f;
	private float maxTimeToCreateObstacle;

	private void Start()
	{
		updateMaxTimeToCreateObstacle();
	}
	private void FixedUpdate()
	{
		if (intervalToCreateObstacle > 1)
		{
			intervalToCreateObstacle -= Time.timeSinceLevelLoad / 100000;
		}
		respawnObstacle();
	}

	private void updateMaxTimeToCreateObstacle()
	{
		maxTimeToCreateObstacle = Time.timeSinceLevelLoad + intervalToCreateObstacle;
	}

	private void respawnObstacle()
	{
		if (maxTimeToCreateObstacle < Time.timeSinceLevelLoad)
		{
			updateMaxTimeToCreateObstacle();
			Instantiate(obstacle, transform);
		}
	}
}
