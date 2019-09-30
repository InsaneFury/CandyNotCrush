using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void ShowAchievement()
    {
        GooglePlayManager.ShowAchievements();
    }

    public void ShowLeaderboard()
    {
        GooglePlayManager.ShowLeaderboards();
    }

    public void LogOut()
    {
        GooglePlayManager.LogOut();
    }
}
