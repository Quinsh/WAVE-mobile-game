using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    public cameraMove cam;
    public float speed;
    bool go = false;
    public bool finish = false;
    int currentSceneIndex;

    public invert invert;
    public comboNumb comboN;
    [SerializeField] GameObject deathEffect;
    [SerializeField] int ComboField1;
    [SerializeField] int ComboField2;
    [SerializeField] int ComboField3;
    [SerializeField] int ComboField4;
    [SerializeField] int ComboField5;
    [SerializeField] onStart onStartScript;

    int ComboFieldSequence;

    bool once11 = true;
    [SerializeField] CanvasGroup black;
    [SerializeField] GameObject blackObj;

    bool watchAd;
    [SerializeField] AdManager adScript;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        watchAd = Random.Range(0, 10) == 1; // probabilty of watching an ad;
        if (watchAd)
        {
            adScript.playVideoAd(); // if a Scene starts, watch ad in one in 10 probability
        }
    }

    public void pressToActivateMove()
    {
        go = true;
    }
    void Update()
    {
        if (go && !finish)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if((transform.position.x >= 6 || transform.position.x <= -6) && once11)
        {
            StartCoroutine(FadeCanvasGroup(black, black.alpha, 1, 1f));
            blackObj.SetActive(true);
            Invoke("loadAgain", 1f);
            once11 = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "obstacle")
        {
            finish = true;
            invert.gravityCancel();

            Invoke("loadAgain", 2f);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("colliding");
        finish = true;
        invert.gravityCancel();

        Invoke("loadAgain", 2f);
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GhostObstacle")
        {
            finish = true;
            invert.gravityCancel();

            Invoke("loadAgain", 2f);
        }

        if (collision.gameObject.tag == "comboArea")
        {
            if (ComboFieldSequence == 0)
            {
                invert.comboCount(ComboField1);
                ComboFieldSequence++;
            }
            else if (ComboFieldSequence == 1)
            {
                invert.comboCount(ComboField2);
                ComboFieldSequence++;
            }
            else if (ComboFieldSequence == 2)
            {
                invert.comboCount(ComboField3);
                ComboFieldSequence++;
            }
            else if (ComboFieldSequence == 3)
            {
                invert.comboCount(ComboField4);
                ComboFieldSequence++;
            }
            else if (ComboFieldSequence == 4)
            {
                invert.comboCount(ComboField5);
                ComboFieldSequence++;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        bool pass;
        if (collision.gameObject.tag == "comboArea")
        {
            pass = invert.stopComboCount();
            if(!pass)
            {
                finish = true;
                invert.gravityCancel();
                gameObject.SetActive(false);
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                cam.StartCoroutine(cam.Shake(1.5f, 0.1f));
                blackObj.SetActive(true);
                Invoke("blackAp", 0.75f);
                Invoke("loadAgain", 1.5f);
            }
        }
    }

    void blackAp()
    {
        onStartScript.StartCoroutine(FadeCanvasGroup(onStartScript.black, 0, 1, 0.75f));
    }
    void loadAgain()
    {
        SceneManager.LoadScene(currentSceneIndex);
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
