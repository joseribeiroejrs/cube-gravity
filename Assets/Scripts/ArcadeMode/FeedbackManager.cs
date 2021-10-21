using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FeedbackManager : MonoBehaviour
{
    public GameObject CurrentLevelPainel;
    public GameObject LevelCompletePainel;
    public GameObject LevelFailedPainel;
    public Text currentLevelText;

	private void Start()
	{
        changeCurrentLevelText();
        StartCoroutine("hideCurrentLevelPainel");
	}

    public void changeCurrentLevelText()
	{
        currentLevelText.text = SceneManager.GetActiveScene().buildIndex.ToString();
    }

    public void showLevelCompletePainel()
	{
        LevelCompletePainel.SetActive(true);
        StartCoroutine("LoadNextLevel");
    }

    public void showLevelFailedPainel()
    {
        StartCoroutine("LoadActiveLevel");
    }

    IEnumerator hideCurrentLevelPainel()
	{
        yield return new WaitForSeconds(3f);
        CurrentLevelPainel.SetActive(false);
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator LoadActiveLevel()
    {
        yield return new WaitForSeconds(1f);
        LevelFailedPainel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
