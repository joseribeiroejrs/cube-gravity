using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsController : MonoBehaviour
{
    public static PointsController Instance { get; private set; }
	private Text scoreText;
	private int points = 0;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			gameObject.SetActive(false);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);

		scoreText = GetComponentInChildren<Text>();
	}

	private void Update()
	{
		scoreText.text = getPoints().ToString();
	}

	public int getPoints()
	{
		return points;
	}

	public void addPoints()
	{
		points++;
	}
}
