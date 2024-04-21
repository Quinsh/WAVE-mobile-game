
using UnityEngine;

public class destroy1f : MonoBehaviour
{
    float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    private void Update()
    {
        transform.position += Time.deltaTime * speed * Vector3.up;
        speed -= 2f * Time.deltaTime;
    }


}
