using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Canvas gameOverCanvas;
	public float slowness = 10f;
	private float originalFixedDeltaTime;

	private void Start()
	{
		originalFixedDeltaTime = Time.fixedDeltaTime;
	}

	public void gameOver()
	{
		StartCoroutine(gameOverCoroutine());
	}

	public void hideGameOver()
	{
		gameOverCanvas.gameObject.SetActive(false);
	}

	IEnumerator gameOverCoroutine()
	{
		showMatrixCamera();
		yield return new WaitForSeconds(1.5f / slowness);
		showGameOverCanvas();
		CanvasController.Instance.setGameOver();
	}

	public void showMatrixCamera()
	{
		Time.timeScale = 1f / slowness;
		Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;
	}

	public void hideMatrixCamera() 
	{
		Time.timeScale = 1f;
		Time.fixedDeltaTime = originalFixedDeltaTime;
	}

	public void showGameOverCanvas()
	{
		gameOverCanvas.gameObject.SetActive(true);
	}
}
