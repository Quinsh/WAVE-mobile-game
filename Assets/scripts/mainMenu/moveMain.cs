using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveMain : MonoBehaviour
{
    public float speed;
    bool finish = false;

    public cameraMain cam;
    Rigidbody2D rig;


    private void Start()
    {
        rig = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!finish)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if(transform.position.y >= 9.8f)
        {
            rig.gravityScale = 0.1f;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            finish = true;
            rig.gravityScale = 0;
        }
    }


}
