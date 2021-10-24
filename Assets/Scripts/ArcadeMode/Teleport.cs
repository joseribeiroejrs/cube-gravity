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
		}
	}
}
