using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitializeMusicToggle : MonoBehaviour
{
    public Toggle musicToggle;
    private string musicPref = "music_pref";

    void Start()
    {
        musicToggle.isOn = getMusicPref();
		Debug.Log("Music Pref: " + getMusicPref().ToString());
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
