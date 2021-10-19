using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleArcade : MonoBehaviour
{
	private FeedbackManager feedbackManager;

	private void Start()
	{
		feedbackManager = FindObjectOfType<FeedbackManager>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		bool isCollisionWithPlayer = collision.CompareTag("Player");
		if (isCollisionWithPlayer)
		{
			feedbackManager.showLevelFailedPainel();
		}
	}
}
