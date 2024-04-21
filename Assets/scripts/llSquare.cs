using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llSquare : MonoBehaviour
{
    public GameObject ef1;
    public GameObject ef2;
    [SerializeField] Transform ball;
    [SerializeField] cameraMove cam;

    public void Update()
    {
        if(transform.position.y <= ball.position.y - 3.5)
        {
            cam.StartCoroutine(cam.Shake(0.3f, 0.3f));
            Instantiate(ef1, transform.position, Quaternion.identity);
            Instantiate(ef2, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
