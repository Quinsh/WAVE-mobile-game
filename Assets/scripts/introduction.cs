using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introduction : MonoBehaviour
{
    [SerializeField] CanvasGroup textC;
    [SerializeField] CanvasGroup image2;
    [SerializeField] CanvasGroup text3;
    [SerializeField] CanvasGroup text4;
    [SerializeField] CanvasGroup AreYouReady;
    [SerializeField] CanvasGroup st1;
    [SerializeField] CanvasGroup refLine;
    [SerializeField] CanvasGroup st2;
    [SerializeField] CanvasGroup st3;
    [SerializeField] CanvasGroup st4;

    private void Start()
    {
        StartCoroutine(FadeCanvasGroup(textC, textC.alpha, 1));
        Invoke("fadeAway", 6f);
        Invoke("start1", 9f);
        Invoke("start2", 15f);
        Invoke("start3", 21f);
        Invoke("start4", 27f);
        Invoke("AreYouReadyy", 33f);
        Invoke("text3view", 46f);
        Invoke("text4view", 55f);
    }
    void AreYouReadyy()
    {
        StartCoroutine(FadeCanvasGroup(AreYouReady, AreYouReady.alpha, 1));
        Invoke("fadeAreYouReady", 3f);
    }
    void start1()
    {
        StartCoroutine(FadeCanvasGroup(st1, st1.alpha, 1));
        StartCoroutine(FadeCanvasGroup(refLine, refLine.alpha, 1));
        Invoke("fadeSt1", 3f);
    }
    void fadeSt1()
    {
        StartCoroutine(FadeCanvasGroup(st1, st1.alpha, 0));
    }
    void start2()
    {
        StartCoroutine(FadeCanvasGroup(st2, st2.alpha, 1, 1));
        Invoke("fadeSt2", 3f);
    }
    void fadeSt2()
    {
        StartCoroutine(FadeCanvasGroup(st2, st2.alpha, 0, 1));
    }
    void start3()
    {
        StartCoroutine(FadeCanvasGroup(st3, st3.alpha, 1, 1));
        Invoke("fadeSt3", 3f);
    }
    void fadeSt3()
    {
        StartCoroutine(FadeCanvasGroup(st3, st3.alpha, 0, 1));
    }
    void start4()
    {
        StartCoroutine(FadeCanvasGroup(st4, st4.alpha, 1, 1));
        Invoke("fadeSt4", 3f);
    }
    void fadeSt4()
    {
        StartCoroutine(FadeCanvasGroup(st4, st4.alpha, 0, 1));
    }

    void text3view()
    {
        StartCoroutine(FadeCanvasGroup(text3, text3.alpha, 1));
        Invoke("fadeText3", 5f);
    }
    void text4view()
    {
        StartCoroutine(FadeCanvasGroup(text4, text4.alpha, 1));
        Invoke("fadeText4", 5f);
    }

    void fadeText3()
    {
        StartCoroutine(FadeCanvasGroup(text3, text3.alpha, 0));
    }
    void fadeText4()
    {
        StartCoroutine(FadeCanvasGroup(text4, text4.alpha, 0));
    }
    void fadeAway()
    {
        StartCoroutine(FadeCanvasGroup(textC, textC.alpha, 0));
    }
    void fadeAreYouReady()
    {
        StartCoroutine(FadeCanvasGroup(AreYouReady, textC.alpha, 0));
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
