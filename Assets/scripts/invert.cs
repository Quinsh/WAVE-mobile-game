using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using MoreMountains.NiceVibrations;

public class invert : MonoBehaviour
{
    public bool allowInvert = true;
    float scale;
    public Rigidbody2D ballR;
    public Transform ball;
    public Rigidbody2D ballR2;
    public Transform ball2;
    bool onlyOnce = true;

    float toleranceArea = 0.55f;
    public GameObject effect1;
    public GameObject effect2;
    public GameObject effect3;
    public GameObject effect4;
    public GameObject effect5;

    public GameObject comboText1;
    public GameObject bigArc;

    int ComboStrikes;
    public cameraMove cameraM;
    Vector3 randomPos;

    public bool passComboArea;
    bool startComboCounting;
    int comboGoal;

    bool isMuted;
    bool vibrationOff;

    bool strongCombo;

    public void Start()
    {
        isMuted = PlayerPrefs.GetInt("MUTED", 0) == 1;
        //vibrationOff = PlayerPrefs.GetInt("VIB", 0) == 1;

        Time.timeScale = 1f;
    }

    public void invertGravity()
    {
     
        if (onlyOnce)
        {
            ballR.gravityScale = -1f;
            if(ballR2 != null)
            {
                ballR2.gravityScale = 1f;
            }
            onlyOnce = false;
        }
        else if (ball.position.x > -toleranceArea && ball.position.x <= toleranceArea) // if you touch the ball when the ball is in a certain area
        {
            ComboStrikes += 1;

            if (ComboStrikes == 1)
            {
                //Instantiate(effect1, ball.position, Quaternion.identity);
                effect1.SetActive(true);
                effect1.transform.position = ball.position;
                effect1.GetComponent<ParticleSystem>().Play();
                effect1.GetComponent<autoDestruct>().fadeAfter2sec();
            }
            if(ComboStrikes >= 2)
            {
                if (!effect2.activeSelf)
                {
                    effect2.SetActive(true);
                    effect2.transform.position = ball.position;
                    effect2.GetComponent<ParticleSystem>().Play();
                    effect2.GetComponent<autoDestruct>().fadeAfter2sec();
                }
                else if (!effect3.activeSelf)
                {
                    effect3.SetActive(true);
                    effect3.transform.position = ball.position;
                    effect3.GetComponent<ParticleSystem>().Play();
                    effect3.GetComponent<autoDestruct>().fadeAfter2sec();
                }
                else if (!effect4.activeSelf)
                {
                    effect4.SetActive(true);
                    effect4.transform.position = ball.position;
                    effect4.GetComponent<ParticleSystem>().Play();
                    effect4.GetComponent<autoDestruct>().fadeAfter2sec();
                }
                else if (!effect5.activeSelf)
                {
                    effect5.SetActive(true);
                    effect5.transform.position = ball.position;
                    effect5.GetComponent<ParticleSystem>().Play();
                    effect5.GetComponent<autoDestruct>().fadeAfter2sec();
                }

            }


            if (ComboStrikes >= 3)
            {
                comboText1.GetComponent<TextMesh>().text = ComboStrikes + " combo";
                if(ComboStrikes==3)
                {
                    comboText1.GetComponent<TextMesh>().fontSize = 55;
                }
                else if (ComboStrikes == 4)
                {
                    comboText1.GetComponent<TextMesh>().fontSize = 60;
                }
                else if (ComboStrikes == 5)
                {
                    comboText1.GetComponent<TextMesh>().fontSize = 65;
                }
                else if (ComboStrikes == 6)
                {
                    comboText1.GetComponent<TextMesh>().fontSize = 70;
                }
                else if (ComboStrikes >= 7)
                {
                    comboText1.GetComponent<TextMesh>().fontSize = 75;
                }

                randomPos = new Vector3(Random.Range(-0.6f, 0.6f), ball.position.y + 0.5f, 0);
                Instantiate(comboText1, randomPos, Quaternion.identity);
            }

            /*if(ComboStrikes == 1)
            {
                FindObjectOfType<AudioManager>().Play("Do1");
            }
            else if (ComboStrikes == 2)
            {
                FindObjectOfType<AudioManager>().Play("Re");
            }
            else if (ComboStrikes == 3)
            {
                FindObjectOfType<AudioManager>().Play("Mi");
            }
            else if (ComboStrikes == 4)
            {
                FindObjectOfType<AudioManager>().Play("Fa");
            }
            else if (ComboStrikes == 5)
            {
                FindObjectOfType<AudioManager>().Play("Sol");
            }
            else if (ComboStrikes == 6)
            {
                FindObjectOfType<AudioManager>().Play("La");
            }
            else if (ComboStrikes == 7)
            {
                FindObjectOfType<AudioManager>().Play("Si");
            }
            else if (ComboStrikes == 8)
            {
                FindObjectOfType<AudioManager>().Play("Do2");
            }
            else if (ComboStrikes >= 9)
            {
                FindObjectOfType<AudioManager>().Play("Do3");
            }*/

            
            /*if(!vibrationOff)
            {
                MMVibrationManager.ContinuousHaptic(0.8f, 1, 0.01f, HapticTypes.LightImpact, this, true, -1, true);
            }*/
            
            //strongCombo = true;
        }
        else
        {
            ComboStrikes = 0;
        }


        /*if (!vibrationOff && !strongCombo)
        {
            MMVibrationManager.ContinuousHaptic(0.25f, 1, 0.01f, HapticTypes.LightImpact, this, true, -1, true);
        }*/
        //strongCombo = false;

        if(allowInvert)
        {
            ballR.gravityScale = -ballR.gravityScale;
            if (ballR2 != null)
            {
                ballR2.gravityScale = -ballR2.gravityScale;
            }
        }

    }

    public void comboCount(int combo)
    {
        startComboCounting = true;
        comboGoal = combo;
    }
    public bool stopComboCount()
    {
        startComboCounting = false;
        Invoke("comboReset", 0.5f);
        return passComboArea;
    }
    void comboReset()
    {
        passComboArea = false;
    }
    public void Update()
    {
        if(ballR.velocity.magnitude >= 6f)
        {
            ballR.velocity = 6f * (ballR.velocity.normalized);
            if (ballR2 != null)
            {
                ballR2.velocity = 6f * (ballR2.velocity.normalized);
            }
        }

        if(startComboCounting)
        {
            if(ComboStrikes >= comboGoal)
            {
                passComboArea = true;
                
            }
        }

    }

    public void gravityCancel()
    {
        ballR.gravityScale = 0;
        if (ballR2 != null)
        {
            ballR2.gravityScale = 0;
        }
    }
    
}

