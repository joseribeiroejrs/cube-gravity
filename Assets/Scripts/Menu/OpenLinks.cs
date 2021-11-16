using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLinks : MonoBehaviour
{
    public void OpenYouTubeChannel()
	{
		string YouTubeLink = "https://www.youtube.com/channel/UCoRtOhYMUFmEXuNHLqFvxuA?sub_confirmation=1";
		Application.OpenURL(YouTubeLink);
	}

	public void OpenTwitchChannel()
	{
		string TwitchLink = "https://www.twitch.tv/srbrigao";
		Application.OpenURL(TwitchLink);
	}
}
