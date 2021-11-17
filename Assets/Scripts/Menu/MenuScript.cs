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
	public GameObject optionsPanel;
	public void PlayEvent()
	{
		arcadeLevels.SetActive(false);
		selectMode.SetActive(true);
		menuPrincipal.SetActive(false);
		optionsPanel.SetActive(false);
		Analytics.CustomEvent("play_clicked");
	}

	public void BackToMenu()
	{
		arcadeLevels.SetActive(false);
		menuPrincipal.SetActive(true);
		optionsPanel.SetActive(false);
		selectMode.SetActive(false);
	}

	public void PlayInfinityMode()
	{
		int INFINITY_LEVEL = 22;
		Analytics.CustomEvent("play_infinity_mode");
		SceneManager.LoadScene(INFINITY_LEVEL);
	}

	public void PlayArcadeMode()
	{
		arcadeLevels.SetActive(true);
		selectMode.SetActive(false);
		menuPrincipal.SetActive(false);
		optionsPanel.SetActive(false);
		Analytics.CustomEvent("play_arcade_mode");
	}

	public void OptionsEvent()
	{
		arcadeLevels.SetActive(false);
		selectMode.SetActive(false);
		menuPrincipal.SetActive(false);
		optionsPanel.SetActive(true);
		Analytics.CustomEvent("options_menu");
	}

	public void CreditsEvent()
	{
		int CREDITS_SCENE_INDEX = 21;
		SceneManager.LoadScene(CREDITS_SCENE_INDEX);
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
