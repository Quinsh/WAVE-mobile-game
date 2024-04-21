using UnityEngine;
using System.Collections;

public class cameraMain: MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

   



    private void LateUpdate()
    {
        if (target.transform.position.y >= 3f)
        {
            Vector3 desiredPos = new Vector3(0, target.position.y, 0) + offset;
            Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
            transform.position = smoothedPos;
        }
        
    }

}
