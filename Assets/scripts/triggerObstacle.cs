using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerObstacle : MonoBehaviour
{
    public GameObject effect;
    public ParticleSystem ef;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(effect!=null)
        {
            effect.SetActive(true);
            ef.Play();
        }
       
        FindObjectOfType<AudioManager>().Play("OnCollision");
    }


}
