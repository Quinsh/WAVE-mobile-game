
using UnityEngine;
using UnityEngine.SceneManagement;

public class movePrologue : MonoBehaviour
{
    public float speed;
    bool go = false;
    bool finish = false;
    int currentSceneIndex;
    [SerializeField] GameObject le;
    [SerializeField] GameObject re;
    bool left = true;
    bool turn = true;

    public invert invert;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        Invoke("action1", 36f);
        Invoke("turnFalse", 6f);
    }

    public void pressToActivateMove()
    {
        if(left && turn)
        {
            Instantiate(le, new Vector3(0, -1, 0), Quaternion.identity);
            left = false;
        }
        else if(!left && turn)
        {
            Instantiate(re, new Vector3(0, -1, 0), Quaternion.identity);
            left = true;
        }
    }

    void turnFalse()
    {
        turn = false;
    }
    void action1()
    {
        go = true;
    }

    void Update()
    {
        if (go && !finish)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (transform.position.x >= 10 || transform.position.x <= -10)
        {
            Invoke("loadAgain", 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            finish = true;
            invert.gravityCancel();

            Invoke("loadAgain", 2f);
        }
    }

    void loadAgain()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }


}
