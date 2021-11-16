using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    private PauseMenu pauseMenu;

	private void Start()
	{
		pauseMenu = FindObjectOfType<PauseMenu>();
	}

	public void PauseAction()
	{
		pauseMenu.Pause();
	}
}
