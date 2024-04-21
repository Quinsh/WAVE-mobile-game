using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    private string playStoreID = "3944131";
    private string appStoreID = "3944130";

    private string videoAd = "video";
    private string rewardedVideoAd = "rewardedVideo";

    public bool isTargetPlayStore = true;
    public bool isTestMode;

    int CurrentSceneIndex;

    bool isMuted;

    [SerializeField] GameObject panel;
    [SerializeField] Button myButton;

    private void Start()
    {
        Advertisement.AddListener(this);
        InitializeAdvertisement();

        isMuted = PlayerPrefs.GetInt("MUTED", 0) == 1;
        myButton.interactable = Advertisement.IsReady(rewardedVideoAd);
    }

    private void InitializeAdvertisement()
    {
        if(isTargetPlayStore)
        {
            Advertisement.Initialize(playStoreID, isTestMode);
            return;
        }
        Advertisement.Initialize(appStoreID, isTestMode);
    }

    public void playVideoAd()
    {
        if (!Advertisement.IsReady(videoAd)) { return; }
        Advertisement.Show(videoAd);
    }
    public void playRewardedVideoAd()
    {
        if (!Advertisement.IsReady(rewardedVideoAd)) { return; }
        Advertisement.Show(rewardedVideoAd);
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
        AudioListener.pause = isMuted;
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
        AudioListener.pause = true;
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        AudioListener.pause = isMuted;
        //throw new System.NotImplementedException();
        switch (showResult)
        {
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Finished:
                if(placementId == rewardedVideoAd)
                {
                    CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                    int savedScene = PlayerPrefs.GetInt("savedSceneIndex", 1);

                    if (savedScene == CurrentSceneIndex)
                    {
                        PlayerPrefs.SetInt("savedSceneIndex", savedScene + 1);
                    }

                    stopMusics(); // for stopping musics between chapters

                    PlayerPrefs.SetInt("playOnce", 0);

                    SceneManager.LoadScene(CurrentSceneIndex + 1);
                }
                if(placementId == videoAd)
                {
                    // he just watched an Interstitial Ad! No rewards
                }
                break;
        }
    }

    void stopMusics()
    {
        if (CurrentSceneIndex == 4)
        {
            FindObjectOfType<AudioManager>().StartCoroutine(FindObjectOfType<AudioManager>().stopFade("MainMenuBGM"));
            Debug.Log("stopMusics) working");
        }
        else if (CurrentSceneIndex == 10)
        {
            FindObjectOfType<AudioManager>().StartCoroutine(FindObjectOfType<AudioManager>().stopFade("GeminiBGM"));
            Debug.Log("stopMusics) working");
        }
        else if (CurrentSceneIndex == 15)
        {
            FindObjectOfType<AudioManager>().StartCoroutine(FindObjectOfType<AudioManager>().stopFade("CancerBGM"));
            Debug.Log("stopMusics) working");
        }
        else if (CurrentSceneIndex == 23)
        {
            FindObjectOfType<AudioManager>().StartCoroutine(FindObjectOfType<AudioManager>().stopFade("LeoBGM"));
            Debug.Log("stopMusics) working");
        }
        else if (CurrentSceneIndex == 28)
        {
            FindObjectOfType<AudioManager>().StartCoroutine(FindObjectOfType<AudioManager>().stopFade("LibraBGM"));
            Debug.Log("stopMusics) working");
        }
        else if (CurrentSceneIndex == 34)
        {
            FindObjectOfType<AudioManager>().StartCoroutine(FindObjectOfType<AudioManager>().stopFade("CapricornusBGM"));
            Debug.Log("stopMusics) working");
        }
        else if (CurrentSceneIndex == 35)
        {
            FindObjectOfType<AudioManager>().StartCoroutine(FindObjectOfType<AudioManager>().stopFade("SiriusBGM"));
            Debug.Log("stopMusics) working");
        }
        else if (CurrentSceneIndex == 36)
        {
            FindObjectOfType<AudioManager>().StartCoroutine(FindObjectOfType<AudioManager>().stopFade("AldebaranBGM"));
            Debug.Log("stopMusics) working");
        }
        else if (CurrentSceneIndex == 37)
        {
            FindObjectOfType<AudioManager>().StartCoroutine(FindObjectOfType<AudioManager>().stopFade("PolarisABGM"));
            Debug.Log("stopMusics) working");
        }
    }

    public void ShowPanel()
    {
        panel.SetActive(true);
    }
    public void HidePanel()
    {
        panel.SetActive(false);
    }

}
