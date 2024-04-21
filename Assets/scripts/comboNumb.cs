using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class comboNumb : MonoBehaviour
{
    public int comboNumber;
    [SerializeField] TextMeshProUGUI text;
    public CanvasGroup panel;
    [SerializeField] invert invert;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(FadeCanvasGroup(panel, panel.alpha, 1, 0.5f));
            text.text = "combo: " + comboNumber;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(invert.passComboArea)
        {
            StartCoroutine(FadeCanvasGroup(panel, panel.alpha, 0, 0.5f));
        }
    }



    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 3f)
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
