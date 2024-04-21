using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg3 : MonoBehaviour
{

    float rotateRate = 5f;
    float count;
    // Update is called once per frame
    void Update()
    {
        if(count>=5)
        {
            rotateRate = -rotateRate;
            count = 0;
        }
        count += Time.deltaTime;
        
        transform.Rotate(0, 0, rotateRate * Time.deltaTime);
    }
}
