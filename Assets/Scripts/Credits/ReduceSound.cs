using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceSound : MonoBehaviour
{
    private MusicController musicController;

	private void Start()
	{
		musicController = FindObjectOfType<MusicController>();
		musicController.sound.volume = .1f;
	}

	private void OnDestroy()
	{
		musicController.sound.volume = 1f;
	}
}
