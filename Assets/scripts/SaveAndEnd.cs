using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndEnd : MonoBehaviour
{
    public cameraMove cam;
    int CurrentSceneIndex;

    private void Start()
    {
        CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        cam.moveC = false;
        Invoke("loadNextScene", 2f);
        
        int savedScene = PlayerPrefs.GetInt("savedSceneIndex", 1);

        if(savedScene == CurrentSceneIndex)
        {
            PlayerPrefs.SetInt("savedSceneIndex", savedScene + 1);
        }

        stopMusics();

        PlayerPrefs.SetInt("playOnce", 0);
    }
    void loadNextScene()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex + 1);
    }

    void stopMusics()
    {
        if(CurrentSceneIndex == 4)
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
}
