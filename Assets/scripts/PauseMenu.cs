using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject menuBar;
    public void OnPause()
    {
        menuBar.SetActive(true);
        Time.timeScale = 0;
    }
    public void OnResume()
    {
        menuBar.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnHome()
    {
        PlayerPrefs.SetInt("playOnce", 0);
        SceneManager.LoadScene(0);
        Time.timeScale = 25;
    }
}
