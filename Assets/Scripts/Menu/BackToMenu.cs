using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
	public GameManager gameManager;
    public void BackToMenuByInfinityMode()
	{
		gameManager.hideMatrixCamera();
		SceneManager.LoadScene(0);
	}
}
