using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public int totalLevels;
    public GameObject levelButton;
    public RectTransform ParentPanel;
	int levelReached;

	private void Awake()
	{
		LevelButtons();
	}

	void LevelButtons()
	{
		if (!PlayerPrefs.HasKey("level"))
		{
			PlayerPrefs.SetInt("level", 1);
		}

		levelReached = PlayerPrefs.GetInt("level");

		for (int i = 0; i < totalLevels; i++)
		{
			int level = i + 1;
			GameObject lvlButton = Instantiate(levelButton);
			lvlButton.transform.SetParent(ParentPanel, false);
			Text buttonText = lvlButton.GetComponentInChildren<Text>();
			buttonText.text = level.ToString();

			lvlButton.GetComponent<Button>().onClick.AddListener(delegate
			{
				LevelSelected(level);
			});

			if (level > levelReached)
			{
				lvlButton.GetComponent<Button>().interactable = false;
			}
		}
	}
	void LevelSelected(int index)
	{
		PlayerPrefs.SetInt("levelSelected", index);
		LoadGamePLayer(index);
	}

	void LoadGamePLayer(int index)
	{
		SceneManager.LoadScene(index);
	}
}
