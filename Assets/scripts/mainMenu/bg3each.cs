using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg3each : MonoBehaviour
{
    float initialYValue;
    float initialXValue;

    // Start is called before the first frame update
    void Start()
    {
        initialYValue = transform.position.y;
        initialXValue = transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 0.1f)
        {
            transform.position -= transform.up * 1f * Time.deltaTime;
        }
        else if (transform.position.y < -0.1f)
        {
            transform.position += transform.up * 1f * Time.deltaTime;
        }

        if(transform.position.y < 0.1f && transform.position.y > -0.1f)
        {
            if(initialYValue > 0)
            {
                transform.position = new Vector3(initialXValue, 6);
            }
            else if (initialYValue < 0)
            {
                transform.position = new Vector3(initialXValue, -6);
            }
        }
    }
}
