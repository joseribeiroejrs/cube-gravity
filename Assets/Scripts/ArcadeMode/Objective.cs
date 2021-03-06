using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Objective : MonoBehaviour
{
	private FeedbackManager feedbackManager;
	public AudioSource SuccessLevelAudio;

	private void Start()
	{
		feedbackManager = FindObjectOfType<FeedbackManager>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		bool isCollisionWithPlayer = collision.CompareTag("Player");
		if (isCollisionWithPlayer)
		{
			showLevelCompletePainel();
			SuccessLevelAudio.gameObject.SetActive(true);
		}
	}

	public void showLevelCompletePainel()
	{
		feedbackManager.showLevelCompletePainel();
	}
}
