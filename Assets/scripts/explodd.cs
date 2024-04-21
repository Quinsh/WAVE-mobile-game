using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodd : MonoBehaviour
{
    [SerializeField] GameObject eff;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(eff, transform.position, Quaternion.identity);
        }
    }
}
