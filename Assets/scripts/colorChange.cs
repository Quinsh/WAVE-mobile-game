using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class colorChange : MonoBehaviour
{
    [SerializeField] float lerpTime;
    [SerializeField] Color myColors;
    [SerializeField] Color ballC;
    [SerializeField] Camera TheCamera;
    [SerializeField] SpriteRenderer ball;
    [SerializeField] TrailRenderer ballT;
    [SerializeField] GameObject effect;
    [SerializeField] cameraMove cam;
    [SerializeField] onStart onstartScript;
    [SerializeField] int LastLevelIndex;
    [SerializeField] bool SiriusSecond;
    [SerializeField] bool titleNotAppear;
    [SerializeField] bool st1;
    [SerializeField] bool st2;
    [SerializeField] TextMeshProUGUI title;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool playIt = PlayerPrefs.GetInt("playOnce", 0) == 0;
        if (LastLevelIndex == 1 && playIt)
        {
            FindObjectOfType<AudioManager>().Play("SiriusBGM");
            PlayerPrefs.SetInt("playOnce", 1);
        }
        else if (LastLevelIndex == 2 && playIt)
        {
            FindObjectOfType<AudioManager>().Play("AldebaranBGM");
            PlayerPrefs.SetInt("playOnce", 1);
        }
        else if (LastLevelIndex == 3 && playIt)
        {
            FindObjectOfType<AudioManager>().Play("PolarisABGM");
            PlayerPrefs.SetInt("playOnce", 1);
        }
        else if (LastLevelIndex == 4 && playIt)
        {
            FindObjectOfType<AudioManager>().Play("RigelBGM");
            PlayerPrefs.SetInt("playOnce", 1);
        }
        StartCoroutine(colorC());
        StartCoroutine(ballColorC());
        ballT.time = 2f;
        Instantiate(effect, transform.position, Quaternion.identity);
        cam.StartCoroutine(cam.Shake(0.2f, 0.2f));
        SpriteRenderer spt = GetComponent<SpriteRenderer>();
        spt.color = new Color(0, 0, 0, 0);

        if (!titleNotAppear)
        {
            onstartScript.ll1();
        }

        if(SiriusSecond)
        {
            trail();
        }
        if(st1)
        {
            trail1();
        }
        if(st2)
        {
            trail2();
        }
    }


    void trail()
    {
        ballT.startColor = new Color(0.274f, 0.274f,0.274f);
        ballT.endColor = Color.clear;
    }

    void trail1()
    {
        ballT.startColor = new Color32(252, 144, 182, 255);
        ballT.endColor = Color.clear;
        title.text = "<u> ?tw!~~!`\n </u>";
    }
    void trail2()
    {
        ballT.startColor = new Color32(226, 226, 226, 255);
        ballT.endColor = Color.clear;
        title.text = "<b> special thanks </b>";
    }


    IEnumerator colorC()
    {
        TheCamera.backgroundColor = Color.Lerp(TheCamera.backgroundColor, myColors, lerpTime * Time.deltaTime);

        if (TheCamera.backgroundColor != myColors)
        {
            yield return new WaitForFixedUpdate();
            StartCoroutine(colorC());
        }
    }
    IEnumerator ballColorC()
    {
        ball.color = Color.Lerp(ball.color, ballC, lerpTime * Time.deltaTime);

        if (ball.color != ballC)
        {
            yield return new WaitForFixedUpdate();
            StartCoroutine(ballColorC());
        }
    }
}
