using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
	public Canvas arcadeLevels;
	public Canvas menuPrincipal;
	public void PlayEvent()
	{
		arcadeLevels.gameObject.SetActive(true);
		menuPrincipal.gameObject.SetActive(false);
	}

	public void BackToMenu()
	{
		arcadeLevels.gameObject.SetActive(false);
		menuPrincipal.gameObject.SetActive(true);
	}

	public void QuitEvent() 
	{
		Application.Quit();
	}
}
