using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public Canvas PointsCanvas;
    public Canvas GameOverCanvas;

    public static CanvasController Instance { get; private set; }

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			gameObject.SetActive(false);
			return;
		}
		Instance = this;
	}

	public void setInGame()
	{
        PointsCanvas.gameObject.SetActive(true);
        GameOverCanvas.gameObject.SetActive(false);
	}

    public void setGameOver()
	{
        PointsCanvas.gameObject.SetActive(false);
        GameOverCanvas.gameObject.SetActive(true);
    }
}
