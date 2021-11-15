using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour
{
    public Text currentHighScoreText;
    public Text highScoreText;
	public Button NewRecord;
	private string INFINITY_HIGH_SCORE = "InfinityHighScore";

	public void showNewRecordOrCurrentHighScore()
	{
		if (isHighScore())
		{
			showNewRecord();
			setHighScore(getCurrentScore());
		} else
		{
			updateHighScoreText();
			showCurrentHighScore();
		}
	}

	private void showNewRecord()
	{
		NewRecord.gameObject.SetActive(true);
		highScoreText.gameObject.SetActive(false);
		currentHighScoreText.gameObject.SetActive(false);
	}

	private void showCurrentHighScore()
	{
		NewRecord.gameObject.SetActive(false);
		highScoreText.gameObject.SetActive(true);
		currentHighScoreText.gameObject.SetActive(true);
	}

	private int getCurrentScore()
	{
		return PointsController.Instance.getPoints();
	}

	private void updateHighScoreText()
	{
		currentHighScoreText.text = getCurrentHighScore().ToString();
	}

	public int getCurrentHighScore()
	{
		return PlayerPrefs.GetInt(INFINITY_HIGH_SCORE);
	}

	public bool isHighScore()
	{
		return getCurrentScore() > getCurrentHighScore();
	}

	public void setHighScore(int score)
	{
		PlayerPrefs.SetInt(INFINITY_HIGH_SCORE, score);
	}
}
