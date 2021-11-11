using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
	public GameObject arcadeLevels;
	public GameObject menuPrincipal;
	public void PlayEvent()
	{
		arcadeLevels.SetActive(true);
		menuPrincipal.SetActive(false);
	}

	public void BackToMenu()
	{
		arcadeLevels.SetActive(false);
		menuPrincipal.SetActive(true);
	}

	public void QuitEvent() 
	{
		Application.Quit();
	}
}
