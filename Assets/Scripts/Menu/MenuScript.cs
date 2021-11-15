using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
	public GameObject arcadeLevels;
	public GameObject menuPrincipal;
	public GameObject selectMode;
	public void PlayEvent()
	{
		arcadeLevels.SetActive(false);
		selectMode.SetActive(true);
		menuPrincipal.SetActive(false);
	}

	public void BackToMenu()
	{
		arcadeLevels.SetActive(false);
		menuPrincipal.SetActive(true);
		selectMode.SetActive(false);
	}

	public void PlayInfinityMode()
	{
		int INFINITY_LEVEL = 21;
		SceneManager.LoadScene(INFINITY_LEVEL);
	}

	public void PlayArcadeMode()
	{
		arcadeLevels.SetActive(true);
		selectMode.SetActive(false);
		menuPrincipal.SetActive(false);
	}
	public void QuitEvent() 
	{
		Application.Quit();
	}
}
