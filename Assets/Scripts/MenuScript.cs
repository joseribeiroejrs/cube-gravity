using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
	private string ARCADE_MODE_LEVEL_001 = "ArcadeLevel001";
	public void PlayEvent()
	{
		SceneManager.LoadScene(ARCADE_MODE_LEVEL_001);
	}

	public void QuitEvent() 
	{
		Application.Quit();
	}
}
