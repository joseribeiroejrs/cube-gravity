using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPoints : MonoBehaviour
{
	public AudioSource SuccessSound;

	private bool isFirstTimePlayedSuccessSound = true;
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
			pointsController.addPoints();
			playSuccessSound();
		}
	}
	public void playSuccessSound()
	{
		if (isFirstTimePlayedSuccessSound)
		{
			SuccessSound.gameObject.SetActive(true);
			isFirstTimePlayedSuccessSound = false;
		}
		else
		{
			SuccessSound.Play();
		}
	}
}
