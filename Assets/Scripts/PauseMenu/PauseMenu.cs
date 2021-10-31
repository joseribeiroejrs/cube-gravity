using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public static bool GameIsPaused = false;
	public Canvas PauseMenuCanvas;
	private void Update()
	{
		if (isEscapePressed())
		{
			changeGameIsPaused();
		}
	}
	public void QuitEvent()
	{
		Application.Quit();
	}

	public void MenuEvent()
	{
		SceneManager.LoadScene(0);
		Resume();
	}

	public void changeGameIsPaused()
	{
		GameIsPaused = !GameIsPaused;
		if (GameIsPaused)
		{
			Resume();
		} else
		{
			Pause();
		}
	}

	public void Resume()
	{
		Time.timeScale = 1f;
		PauseMenuCanvas.gameObject.SetActive(false);
	}

	public void Pause()
	{
		Time.timeScale = 0f;
		PauseMenuCanvas.gameObject.SetActive(true);
	}

	public bool isEscapePressed ()
	{
		return Input.GetKeyDown(KeyCode.Escape);
	}
}
