using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class FeedbackCollector2 : MonoBehaviour
{
    public GameObject a1;
    public Button submit;
    public TextMeshProUGUI s1;

    [SerializeField] Toggle[] t1;
    [SerializeField] Toggle[] t2;

    [SerializeField] CanvasGroup first;
    [SerializeField] CanvasGroup second;
    [SerializeField] CanvasGroup third;
    [SerializeField] GameObject questionary;

    string ads;
    string dif;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/3/d/e/1FAIpQLSeZYgNOcNbaIVM_2OdnUNAaJ-xWveq0rspEpCYSxnaa0aE4jw/formResponse";


    public void Start()
    {
        StartCoroutine(FadeCanvasGroup(first, first.alpha, 1, 1));
        Invoke("sec", 5f);
    }

    void sec()
    {
        StartCoroutine(FadeCanvasGroup(first, first.alpha, 0, 2));
        Invoke("thi", 2f);
    }
    void thi()
    {
        questionary.SetActive(true);
        StartCoroutine(FadeCanvasGroup(second, second.alpha, 1, 1));
    }


    public void Send()
    {
        for (int i = 0; i < 5; i++)
        {
            if (t1[i].isOn)
            {
                ads = (i + 1).ToString();
            }
        }
        for (int i = 0; i < 5; i++)
        {
            if (t2[i].isOn)
            {
                dif = (i + 1).ToString();
            }
        }

        StartCoroutine(Post(s1.text, ads, dif));
        submit.interactable = false;

        questionary.SetActive(false);
        StartCoroutine(FadeCanvasGroup(third, third.alpha, 1, 1));

        Invoke("goToLevel11", 3f);
    }

    void goToLevel11()
    {
        SceneManager.LoadScene(11);
    }

    IEnumerator Post(string ss1, string ss2, string ss3)
    {
        WWWForm form = new WWWForm();

        form.AddField("entry.1515126426", ss1);
        form.AddField("entry.350885167", ss2);
        form.AddField("entry.179175080", ss3);
 



        UnityWebRequest www = UnityWebRequest.Post(BASE_URL, form);

        yield return www.SendWebRequest();

        /*byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);
        yield return www;*/

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
