using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onStart: MonoBehaviour
{
    [SerializeField] CanvasGroup title;
    public CanvasGroup black;
    public GameObject blackObj;
    public bool lastLevels;
    // Start is called before the first frame update
    void Start()
    {
        bool isMuted = PlayerPrefs.GetInt("MUTED", 0) == 1;
        AudioListener.pause = isMuted;


        if (title!=null && !lastLevels)
        {
            StartCoroutine(FadeCanvasGroup(title, title.alpha, 1, 2f));
        }

        if(black!=null)
        {
            StartCoroutine(FadeCanvasGroup(black, black.alpha, 0, 1f));
            Invoke("setBlackFalse", 1f);
        }
        Invoke("fadeOut", 2f);

    }
    public void ll1()
    {
        StartCoroutine(FadeCanvasGroup(title, title.alpha, 1, 0.1f));
        Invoke("ll2", 0.5f);
    }
    void ll2()
    {
        StartCoroutine(FadeCanvasGroup(title, title.alpha, 0, 5f));
    }
    void fadeOut()
    {
        StartCoroutine(FadeCanvasGroup(title, title.alpha, 0, 2f));
    }
    void setBlackFalse()
    {
        blackObj.SetActive(false);
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
