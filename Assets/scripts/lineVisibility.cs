using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineVisibility : MonoBehaviour
{
    Transform ball;

    public void Start()
    {
        ball = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    public void Update()
    {
        if(ball.position.y - transform.position.y > 3.5)
        {
            gameObject.SetActive(false);
        }
        
    }
}
