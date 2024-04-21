using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public void fadeAfter2sec()
    {
        Invoke("fade", 2f);
    }

    void fade()
    {
        gameObject.SetActive(false);
    }

}
