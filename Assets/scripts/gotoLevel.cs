using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotoLevel : MonoBehaviour
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

        if (savedScene == CurrentSceneIndex)
        {
            PlayerPrefs.SetInt("savedSceneIndex", savedScene + 1);
        }

        FindObjectOfType<AudioManager>().StartCoroutine(FindObjectOfType<AudioManager>().stopFade("GeminiBGM"));

        PlayerPrefs.SetInt("playOnce", 0);
    }
    void loadNextScene()
    {
        SceneManager.LoadScene(39);
    }
}
