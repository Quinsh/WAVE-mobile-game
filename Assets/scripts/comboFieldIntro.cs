using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comboFieldIntro : MonoBehaviour
{
    [SerializeField] GameObject panelG;
    [SerializeField] CanvasGroup panel;
    [SerializeField] GameObject img1;
    [SerializeField] GameObject img2;
    [SerializeField] GameObject img3;
    [SerializeField] GameObject txt1;
    [SerializeField] GameObject txt2;
    int count;

    private void Start()
    {
        StartCoroutine(FadeCanvasGroup(panel, panel.alpha, 1, 1f));
        
    }

    public void OnClick()
    {
        if(count == 0)
        {
            img1.SetActive(false);
            img2.SetActive(true);
        }
        else if(count == 1)
        {
            img2.SetActive(false);
            txt1.SetActive(false);
            img3.SetActive(true);
            txt2.SetActive(true);
        }
        else if(count == 2)
        {
            img3.SetActive(false);
            txt2.SetActive(false);
            panelG.SetActive(false);
        }

        count++;
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
