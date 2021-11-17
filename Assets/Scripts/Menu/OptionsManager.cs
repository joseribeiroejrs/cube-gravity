using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    private MusicController musicController;
    public Toggle musicToggle;
	
	private string musicPref = "music_pref";
	private bool wasStartedMusicToggle = false;
	private bool itsGameStartup = true;
	private bool isWaitingForStartupMusic = false;

	private void Start()
	{
		StartCoroutine("GameStartupCountdown");
		musicController = FindObjectOfType<MusicController>();
		Debug.Log("A musica iniciou com estado: " + getMusicPref().ToString());
	}

	private void Update()
	{
		StartMusicToggle();
	}

	public void StartMusicToggle()
	{
		if (!wasStartedMusicToggle)
		{
			musicToggleChange(getMusicPref());
			wasStartedMusicToggle = true;
			musicToggle.onValueChanged.AddListener(delegate {
				Debug.Log("Changed musicToggle: " + musicToggle.isOn);
				musicToggleChange(musicToggle.isOn);
			});
		}
	}

	public void musicToggleChange(bool isMusicPlayed)
	{
		if (isMusicPlayed)
		{
			if (itsGameStartup)
			{
				StartCoroutine("PlaySounds");
				itsGameStartup = false;
			}

			if (!musicController.sound.isPlaying && !isWaitingForStartupMusic)
			{
				musicController.sound.Play();
			}
		}

		if (!isMusicPlayed)
		{
			musicController.sound.Pause();
		}

		setMusicPref(isMusicPlayed);
	}

	IEnumerator GameStartupCountdown()
	{
		itsGameStartup = true;
		yield return new WaitForSeconds(5.5f);
		itsGameStartup = false;
	}

	IEnumerator PlaySounds()
	{
		isWaitingForStartupMusic = true;
		musicController.sound.Pause();
		yield return new WaitForSeconds(5.5f);
		musicController.sound.Play();
		isWaitingForStartupMusic = false;
	}

	public void setMusicPref(bool preferenceMusic)
	{
		PlayerPrefs.SetInt(musicPref, preferenceMusic ? 1 : 0);
	}

	public bool getMusicPref()
	{
		int pref = PlayerPrefs.GetInt(musicPref);
		if (pref != 1 && pref != 0)
		{
			setMusicPref(true);
			musicToggle.isOn = true;
		}
		return pref == 1;
	}
}
