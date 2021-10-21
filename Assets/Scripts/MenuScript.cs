using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
	private int ARCADE_MODE_LEVEL_001 = 1;
	public void PlayEvent()
	{
		SceneManager.LoadScene(ARCADE_MODE_LEVEL_001);
	}

	public void QuitEvent() 
	{
		Application.Quit();
	}
}
