using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using System;

public class AdManager : MonoBehaviour
{
    private string gameIDAndroid = "3317321";
    private string videoKey = "video";
    private string videoRewardedID = "rewardedVideo";

    private void Awake()
    {
        Advertisement.Initialize(gameIDAndroid, true);
    }

    //Se encarga de ejecutar las funciones mediante llamadas de buttons o etc de UI
    public void UIWatchAd()
    {
        WatchVideoAd(VideoAdEnded);
    }
    public void UIWatchRewardedAd()
    {
        WatchRewardedVideoAd(VideoAdRewardedEnded);
    }

    //Se encarga de reproducir el Ad o avisar si no esta listo
    public void WatchVideoAd(Action<ShowResult> result)
    {
        if (Advertisement.IsReady(videoKey))
        {
            ShowOptions so = new ShowOptions();
            so.resultCallback = result;
            Advertisement.Show(videoKey);
        }
        else
        {
            Debug.Log("No cargo el video o hay problema de conexion");
        }
    }
    public void WatchRewardedVideoAd(Action<ShowResult> result)
    {
        if (Advertisement.IsReady(videoRewardedID))
            Advertisement.Show(videoRewardedID);
        else
        {
            Debug.Log("No cargo el video o hay problema de conexion");
        }
    }

    //Gestion el resultado del Ad (si se skipeo, si se cerro o si se vio completo)
    public void VideoAdEnded(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:
                Debug.Log("El ad fallo");
                break;
            case ShowResult.Skipped:
                Debug.Log("El ad fue skipeado");
                break;
            case ShowResult.Finished:
                Debug.Log("El ad termino correctamente.");
                break;
            default:
                break;
        }
    }
    public void VideoAdRewardedEnded(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:
                Debug.Log("El ad rewarded fallo");
                break;
            case ShowResult.Skipped:
                Debug.Log("El ad rewarded fue skipeado");
                break;
            case ShowResult.Finished:
                Debug.Log("El ad rewarded termino correctamente.");
                break;
            default:
                break;
        }
    }
}
