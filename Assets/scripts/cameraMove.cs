using UnityEngine;
using System.Collections;

public class cameraMove : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public bool moveC = true;



    private void LateUpdate()
    {
        if(moveC)
        {
            Vector3 desiredPos = new Vector3(0, target.position.y, 0) + offset;
            Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
            transform.position = smoothedPos;
        }
    }



    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.position;

        float elapsed = 0.0f;
        

        while (elapsed < duration)
        {
            float x = Random.Range(originalPos.x - (1f*magnitude), originalPos.x + (1f*magnitude));
            float y = Random.Range(originalPos.y - (1f*magnitude), originalPos.y + (1f*magnitude));

            transform.position = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
