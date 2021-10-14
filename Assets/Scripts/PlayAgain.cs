using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
	public GameManager gameManager;
    public void playAgain()
	{
		gameManager.hideMatrixCamera();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
