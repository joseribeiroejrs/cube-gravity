using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Objective : MonoBehaviour
{
	public GameObject LevelCompletePainel;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		bool isCollisionWithPlayer = collision.CompareTag("Player");
		if (isCollisionWithPlayer)
		{
			LevelCompletePainel.SetActive(true);
			StartCoroutine("LoadNextLevel");
		}
		Debug.Log("Level Complete" + isCollisionWithPlayer);
	}

	IEnumerator LoadNextLevel()
	{
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
