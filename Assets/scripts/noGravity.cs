using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noGravity : MonoBehaviour
{
    [SerializeField] invert inv;
    [SerializeField] move mov;
    [SerializeField] Rigidbody2D ball;
    float gScale;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inv.allowInvert = false;
            mov.finish = true;
            gScale = ball.gravityScale;
            ball.gravityScale = 0;
            ball.velocity = new Vector2(ball.velocity.x, 2f);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inv.allowInvert = true;
            mov.finish = false;
            ball.gravityScale = gScale;
            ball.velocity = new Vector2(ball.velocity.y, 0);
        }
    }
}
