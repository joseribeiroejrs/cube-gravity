using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FeedbackManager : MonoBehaviour
{
    public GameObject LevelCompletePainel;
    public GameObject LevelFailedPainel;

    public void showLevelCompletePainel()
	{
        LevelCompletePainel.SetActive(true);
        StartCoroutine("LoadNextLevel");
    }

    public void showLevelFailedPainel()
    {
        StartCoroutine("LoadActiveLevel");
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
