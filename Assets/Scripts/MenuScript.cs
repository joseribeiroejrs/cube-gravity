using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
	private int INFINITY_MODE_INDEX = 1;
    public void PlayEvent()
	{
		SceneManager.LoadScene(INFINITY_MODE_INDEX);
	}

	public void QuitEvent()
	{
		Application.Quit();
	}
}
