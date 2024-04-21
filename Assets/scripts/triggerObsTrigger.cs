using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerObsTrigger : MonoBehaviour
{
    public GameObject effect;
    public ParticleSystem ef;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        effect.SetActive(true);
        ef.Play();
        FindObjectOfType<AudioManager>().Play("OnCollision");
    }
}
