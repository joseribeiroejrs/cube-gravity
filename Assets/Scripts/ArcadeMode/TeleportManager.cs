using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public float lastTeleport;
	public float minimumTimeToTeleport = .1f;
	public Canvas TransitionCanvas;
	public AudioSource TeleportSound;
	private bool showTransition = false;

	public bool canTeleport ()
	{
		return (Time.timeSinceLevelLoad - lastTeleport) > minimumTimeToTeleport;
	}

    public void saveTimePlayerTeleported()
	{
		lastTeleport = Time.timeSinceLevelLoad;
		if (!showTransition)
		{
			StartCoroutine("showTransitionCanvas");
		}
	}

	IEnumerator showTransitionCanvas()
	{
		showTransition = true;
		TransitionCanvas.gameObject.SetActive(true);
		TeleportSound.gameObject.SetActive(true);
		yield return new WaitForSeconds(.4f);
		TransitionCanvas.gameObject.SetActive(false);
		showTransition = false;
		TeleportSound.gameObject.SetActive(false);
	}
}
