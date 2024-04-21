using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endll : MonoBehaviour
{
    public cameraMove cam;
    [SerializeField] CanvasGroup title;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject pause;
    int CurrentSceneIndex;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        cam.moveC = false;
        PlayerPrefs.SetInt("playOnce", 0);

        Invoke("fadeBall", 3f);
        StartCoroutine(FadeCanvasGroup(title, title.alpha, 1, 5f));
        Invoke("goMainMenu", 10f);
    }

    void fadeBall()
    {
        ball.SetActive(false);
        pause.SetActive(false);
    }

    void goMainMenu()
    {
        SceneManager.LoadScene(0);
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

}
