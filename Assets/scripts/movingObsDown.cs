using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingObsDown : MonoBehaviour
{
    [SerializeField] float movingDistance;
    [SerializeField] float speed;
    float destiny;
    public bool moveUp;
    bool onlyOnce;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(moveUp && !onlyOnce)
        {
            destiny = transform.position.y + movingDistance;
            StartCoroutine(moveUpp());
            onlyOnce = true;
        }
        else if(!moveUp && !onlyOnce)
        {
            destiny = transform.position.y - movingDistance;
            StartCoroutine(move());
            onlyOnce = true;
        }
    }
    IEnumerator move()
    {
        while(transform.position.y > destiny)
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
}
