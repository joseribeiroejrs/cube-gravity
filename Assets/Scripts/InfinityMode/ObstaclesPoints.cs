using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPoints : MonoBehaviour
{
    private PointsController pointsController;
	private int PLAYER_LAYER = 6;

	private void Awake()
	{
		pointsController = FindObjectOfType<PointsController>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		int layer = collision.gameObject.layer;

		if (layer == PLAYER_LAYER)
		{
			Debug.Log("Colidi e vou adicionar pontos");
			pointsController.addPoints();
		}
	}
}
