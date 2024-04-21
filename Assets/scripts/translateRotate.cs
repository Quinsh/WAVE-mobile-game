using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translateRotate : MonoBehaviour
{
    [SerializeField] float movingDistance;
    [SerializeField] float speed;
    float destiny;
    public bool moveUp;
    bool onlyOnce;
    public bool movee;
    public float rotatingTimer;
    public float rotateSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (movee && moveUp && !onlyOnce)
        {
            destiny = transform.position.y + movingDistance;
            StartCoroutine(moveUpp());
            StartCoroutine(rot());
            onlyOnce = true;
        }
        else if (movee && !moveUp && !onlyOnce)
        {
            destiny = transform.position.y - movingDistance;
            StartCoroutine(move());
            StartCoroutine(rot());
            onlyOnce = true;
        }

        if(!movee && !onlyOnce)
        {
            StartCoroutine(rot());
            onlyOnce = true;
        }

    }
    IEnumerator move()
    {
        while (transform.position.y > destiny)
        {
            transform.Translate(-Vector2.up * Time.deltaTime * speed);
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator moveUpp()
    {
        while (transform.position.y < destiny)
        {
            transform.Translate(Vector2.up * Time.deltaTime * speed);
            yield return new WaitForEndOfFrame();
        }

    }
    IEnumerator rot()
    {
        float time = 0;

        while (time < rotatingTimer)
        {
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
            time += Time.deltaTime;
        }

    }
}