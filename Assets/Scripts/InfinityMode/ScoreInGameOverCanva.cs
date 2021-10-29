using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreInGameOverCanva : MonoBehaviour
{
    public Text scoreText;

	private void Start()
	{
		scoreText.text = PointsController.Instance.getPoints().ToString();
	}
}
