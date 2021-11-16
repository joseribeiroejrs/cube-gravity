using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
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
		Analytics.CustomEvent("play_clicked");
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
		Analytics.CustomEvent("play_infinity_mode");
		SceneManager.LoadScene(INFINITY_LEVEL);
	}

	public void PlayArcadeMode()
	{
		arcadeLevels.SetActive(true);
		selectMode.SetActive(false);
		menuPrincipal.SetActive(false);
		Analytics.CustomEvent("play_arcade_mode");
	}

	public void BackToMenuByInfinityMode()
	{
		SceneManager.LoadScene(0);
	}

	public void QuitEvent() 
	{
		Application.Quit();
	}
}
