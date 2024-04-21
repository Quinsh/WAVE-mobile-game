using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using MoreMountains.NiceVibrations;


public class controls : MonoBehaviour
{
    [SerializeField] CanvasGroup panel;
    [SerializeField] CanvasGroup PlayButton;
    [SerializeField] GameObject honors;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject levelsMenu;
    [SerializeField] GameObject bg1;
    [SerializeField] GameObject bg2;
    [SerializeField] GameObject title;
    [SerializeField] cameraMain cameraScript;
    [SerializeField] GameObject infoPanel;
    [SerializeField] GameObject Play;
    [SerializeField] GameObject LevelButton;
    [SerializeField] Text muteButtonText;
    [SerializeField] Text VibButtonText;
    [SerializeField] GameObject ball;
    public float ballY;
    bool open = true;
    bool openI = true;
    bool openl = true;

    bool isMuted;
    bool vibrationOff;

    int countCoroutine = 0;
    public float speed;
    public float speedDecreaseRate;

    private void Start()
    {
        int rd = Random.Range(0, 2);
        if(rd == 0)
        {
            bg1.SetActive(true);
            bg2.SetActive(false);
        }
        else
        {
            bg1.SetActive(false);
            bg2.SetActive(true);
        }
        StartCoroutine(FadeCanvasGroup(panel, panel.alpha, 1));
        Invoke("fadeAway", 3f);
        Invoke("fadeAway1", 6f);

        settingsSettings();

        Invoke("sc", 7f);
    }

    void sc()
    { StartCoroutine(blink()); }

    IEnumerator blink()
    {
        if (PlayButton.alpha == 0)
        {
            PlayButton.alpha = 1;
        }
        else if(PlayButton.alpha == 1)
        {
            PlayButton.alpha = 0;
        }
        countCoroutine++;

        yield return new WaitForSeconds(1f);
        if(countCoroutine <= 50)
        {
            StartCoroutine(blink());
        }
    }
    void settingsSettings()
    {
        isMuted = PlayerPrefs.GetInt("MUTED", 0) == 1;
        //vibrationOff = PlayerPrefs.GetInt("VIB", 0) == 1;

        if(isMuted)
        {
            muteButtonText.text = "MUSIC: OFF";
        }
        else if(!isMuted)
        {
            muteButtonText.text = "MUSIC: ON";
        }

        /*if(vibrationOff)
        {
            VibButtonText.text = "VIBRATIONS: OFF";
        }
        else if (!vibrationOff)
        {
            VibButtonText.text = "VIBRATIONS: ON";
        }*/

        AudioListener.pause = isMuted;
    }
    void fadeAway()
    {
        StartCoroutine(FadeCanvasGroup(panel, panel.alpha, 0));
    }
    void fadeAway1()
    {
        honors.SetActive(false);
    }
    IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 3f)
    {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while (true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForEndOfFrame();
        }
    }

    public void OnClickSettings()
    {
        /*if(!vibrationOff)
        {
            MMVibrationManager.Haptic(HapticTypes.Selection);
        }*/
        
        if (open)
        {
            settingsPanel.SetActive(true);
            levelsMenu.SetActive(false);
            infoPanel.SetActive(false);
            open = false;
            openl = true;
            openI = true;

            title.SetActive(true);
            cameraScript.offset = new Vector3(0, -3f, -10f);
            Play.SetActive(false);
            LevelButton.SetActive(false);
        }
        else
        {
            settingsPanel.SetActive(false);
            open = true;
            Play.SetActive(true);
            LevelButton.SetActive(true);
        }
    }
    public void OnClickPlay()
    {
        /*if(!vibrationOff)
        {
            MMVibrationManager.Haptic(HapticTypes.Selection);
        }*/


        Invoke("loadSavedScene", 0.6f);


        title.SetActive(false);
        cameraScript.offset = new Vector3(0, -5.7f, -10f);
        LevelButton.SetActive(false);
        Play.SetActive(false);

    }

    public void OpenLevelsMenu()
    {
        /*if (!vibrationOff)
        {
            MMVibrationManager.Haptic(HapticTypes.Selection);
        }*/

        if (openl)
        {
            levelsMenu.SetActive(true);

            settingsPanel.SetActive(false);
            infoPanel.SetActive(false);

            open = true;
            openI = true;
            openl = false;

            title.SetActive(true);
            cameraScript.offset = new Vector3(0, -3f, -10f);
            Play.SetActive(false);
        }
        else
        {
            Play.SetActive(true);
            levelsMenu.SetActive(false);
            openl = true;
            openI = true;
        }
        
    }

    public void OnClickInformations()
    {
        /*if (!vibrationOff)
        {
            MMVibrationManager.Haptic(HapticTypes.Selection);
        }*/

        if (openI)
        {
            title.SetActive(false);
            cameraScript.offset = new Vector3(0, -4.35f, -10f);
            settingsPanel.SetActive(false);
            levelsMenu.SetActive(false);
            open = true;
            openI = false;
            openl = true;
            infoPanel.SetActive(true);
            Play.SetActive(false);
            LevelButton.SetActive(false);
        }
        else if(!openI)
        {
            title.SetActive(true);
            cameraScript.offset = new Vector3(0, -3f, -10f);
            openI = true;
            infoPanel.SetActive(false);
            Play.SetActive(true);
            LevelButton.SetActive(true);
        }
        

    }

    public void OnClickMute()
    {
        /*if (!vibrationOff)
        {
            MMVibrationManager.Haptic(HapticTypes.Selection);
        }*/

        isMuted = !isMuted;
        AudioListener.pause = isMuted;
        PlayerPrefs.SetInt("MUTED", isMuted ? 1 : 0);

        settingsSettings();
    }
    public void OnClickVibrationSettings()
    {
        /*vibrationOff = !vibrationOff;

        if (!vibrationOff)
        {
            MMVibrationManager.Haptic(HapticTypes.Selection);
        }

        PlayerPrefs.SetInt("VIB", vibrationOff ? 1 : 0);

        settingsSettings();
        */
    }

    public void Rate()
    {
        Application.OpenURL("market://details?id=com.Tinypiece.wave"); // change this 
    }

    void loadSavedScene()
    {
        int savedScene = PlayerPrefs.GetInt("savedSceneIndex", 1);
        SceneManager.LoadScene(savedScene);
    }
}
