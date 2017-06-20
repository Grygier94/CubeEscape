using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class MenuManager : MonoBehaviour {

    bool exitConfirmed;

    void Start () {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();

        Social.localUser.Authenticate(null);
        SaveLoadData.Load();
	}

    //Wyjdz po dwukrotnym wcisnienciu back buttona
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (exitConfirmed)
                Application.Quit();
            else
                exitConfirmed = true;
        }

        if (Input.touchCount > 0 && exitConfirmed)
            exitConfirmed = false;
    }
    
    public void ShowAchievements()
    {
        if (Social.localUser.authenticated)
            Social.ShowAchievementsUI();
        else
        {
            Social.localUser.Authenticate(null);           
        }
    }

    public void ShowLeaderboards()
    {
        if (Social.localUser.authenticated)
            PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_highscores);
        else
        {
            Social.localUser.Authenticate(null);
        }
    }
}
