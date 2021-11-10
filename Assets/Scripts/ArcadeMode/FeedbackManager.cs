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
    public Text completedLevelText;

    public float DISPLAY_TIME_PANELS = 3f;

    private void Start()
	{
        changeCurrentLevelText();
        StartCoroutine("hideCurrentLevelPainel");
	}

    public void changeCurrentLevelText()
	{
        string currentLevel = SceneManager.GetActiveScene().buildIndex.ToString();
        currentLevelText.text = currentLevel;
        completedLevelText.text = currentLevel;
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
        yield return new WaitForSeconds(DISPLAY_TIME_PANELS);
        CurrentLevelPainel.SetActive(false);
    }

    IEnumerator LoadNextLevel()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        yield return new WaitForSeconds(DISPLAY_TIME_PANELS);
        setLevelReached(nextLevel);
        SceneManager.LoadScene(nextLevel);
    }

    IEnumerator LoadActiveLevel()
    {
        yield return new WaitForSeconds(1f);
        LevelFailedPainel.SetActive(true);
        yield return new WaitForSeconds(DISPLAY_TIME_PANELS);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void setLevelReached(int level)
	{
        int levelReached = PlayerPrefs.GetInt("level");
        if (level > levelReached)
		{
            PlayerPrefs.SetInt("level", level);
		}
    }
}
