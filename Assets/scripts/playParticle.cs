using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playParticle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ps.Play();
    }
}
