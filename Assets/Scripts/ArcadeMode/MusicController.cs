using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
	public AudioSource sound;
	public static MusicController Instance { get; private set; }
	void Awake()
	{
		if (Instance != null && Instance != this)
		{
			gameObject.SetActive(false);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);
		StartCoroutine("PlaySounds");
	}

	IEnumerator PlaySounds()
	{
		sound.Pause();
		yield return new WaitForSeconds(5.5f);
		sound.Play();
	}
}
