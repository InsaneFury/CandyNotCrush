using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class GooglePlayManager : MonoBehaviour
{
    int points = 0;
    public Text pointText;
    public string leaderBoard, acheivementID;

#if UNITY_ANDROID
    // Start is called before the first frame update
    void Start()
    {
        InitializeGPS();
        LogIn();
    }

    private void InitializeGPS()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
    }

    public void LogIn()
    {
        Social.localUser.Authenticate((bool success) =>
        {

            if (success)
            {
                Debug.Log("Logged in successfuly");
            }
            else
            {
                Debug.Log("Failed to log in");
            }
            // handle success or failure
        });
    }

    public static void LogOut()
    {
        PlayGamesPlatform.Instance.SignOut();
    }

    public static void UnlockAchievement(string id)
    {
        Social.ReportProgress(id, 100, (bool success) =>
        {
            // handle success or failure
        });
    }

    public static void ShowAchievements()
    {
        Social.ShowAchievementsUI();
    }

    public static void ShowLeaderboards()
    {
        Social.ShowLeaderboardUI();
    }

    public void UploadScore(int score)
    {
        Social.ReportScore(score, leaderBoard, (bool success) =>
        {
            if (success)
            {
                Debug.Log("log to leaderboard success");
            }
            else
            {
                Debug.Log("log to leaderboard failed");
            }

                // handle success or failure
            });
    }
#endif
}
