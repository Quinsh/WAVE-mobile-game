using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateRhythm : MonoBehaviour
{
    public float rhythm;
    public float rotateAngle;
    public int times;
    int count;
    float c;
    bool onlyonce = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(onlyonce)
        {
            StartCoroutine(rot());
            onlyonce = false;
        }
        
    }

    IEnumerator rot()
    {
        /*c = rhythm;
        while(count<times)
        {
            if (c >= rhythm)
            {
                
                c = 0;
                count++;
            }
            c += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }*/

        if(count <= times)
        {
            transform.Rotate(Vector3.forward * rotateAngle);
            count++;
        }
        yield return new WaitForSeconds(rhythm);
        StartCoroutine(rot());

    }
}
