using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onColli : MonoBehaviour
{
    [SerializeField] CanvasGroup title;
    [SerializeField] CanvasGroup img;
    [SerializeField] CanvasGroup icon1;
    [SerializeField] CanvasGroup icon2;
    [SerializeField] CanvasGroup icon3;
    [SerializeField] CanvasGroup icon4;

    [SerializeField] [Range(0f, 1f)] float lerpTime;
    [SerializeField] Color myColors;
    [SerializeField] Camera TheCamera;

    [SerializeField] GameObject effect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(FadeCanvasGroup(title, title.alpha, 1));
        StartCoroutine(colorChange());
        StartCoroutine(FadeCanvasGroup(img, 1, 0, 2));
        StartCoroutine(FadeCanvasGroup(icon1, title.alpha, 1));
        StartCoroutine(FadeCanvasGroup(icon2, title.alpha, 1));
        StartCoroutine(FadeCanvasGroup(icon3, title.alpha, 1));
        StartCoroutine(FadeCanvasGroup(icon4, title.alpha, 1));


        Instantiate(effect, new Vector3(0, 5.3f, 0), Quaternion.identity);

        if (Time.timeScale == 25f)
        {
            Time.timeScale = 1f;
        }

        PlayerPrefs.SetInt("playOnce", 0);
    }

    IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTimee = 1f)
    {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTimee;

        while (true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTimee;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForEndOfFrame();
        }
    }



    IEnumerator colorChange()
    {
        TheCamera.backgroundColor = Color.Lerp(TheCamera.backgroundColor, myColors, lerpTime * Time.deltaTime);

        if (TheCamera.backgroundColor != myColors)
        {
            yield return new WaitForFixedUpdate();
            StartCoroutine(colorChange());
        }
    }


}
