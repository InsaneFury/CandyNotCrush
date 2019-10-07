using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsManager : MonoBehaviour
{
    private void Awake()
    {
        LevelEnded(1,3,500);
    }

    public void LevelEnded(int lvl,int lives,int score)
    {
        Analytics.CustomEvent("level_finished", new Dictionary<string, object>{
            { "levels",lvl},{ "lives",lives},{ "score",score}

        });
            
    }
}
