using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject TeleportTo;
	public TeleportManager teleportManager;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player") && teleportManager.canTeleport())
		{
			collision.transform.position = TeleportTo.transform.position;
			teleportManager.saveTimePlayerTeleported();
			StartCoroutine("hideTrailPlayer");
		}
	}

	private IEnumerator hideTrailPlayer()
	{
		PlayerArcade playerObject = FindObjectOfType<PlayerArcade>();
		float oldTime = playerObject.playerTrail.time;
		playerObject.playerTrail.time = 0;
		yield return new WaitForSeconds(.1f);
		playerObject.playerTrail.time = oldTime;
	}
}
