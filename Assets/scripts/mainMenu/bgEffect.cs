using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgEffect : MonoBehaviour
{
    float scaleChangeRate = 0.1f;
    float time;
    SpriteRenderer sprt;
    // Update is called once per frame

    private void Start()
    {
        sprt = GetComponent<SpriteRenderer>();
        sprt.color = new Color32(255, 255, 255, 50);
        if(sprt.sprite.name == "Square")
        {
            sprt.color = new Color32(255, 255, 255, 25);
        }
    }
    void Update()
    {
        transform.Rotate(0, 0, 22.5f * Time.deltaTime);
        
        transform.localScale += new Vector3(scaleChangeRate * Time.deltaTime, scaleChangeRate * Time.deltaTime);

        if(time>=2)
        {
            scaleChangeRate = -scaleChangeRate;
            time = 0;
        }
        time += Time.deltaTime;
    }
}
