using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    void LateUpdate()
    {
        float pinchAmount = 0;
        Quaternion desiredRotation = transform.rotation;

        DetectTouchMovement.Calculate();

        if (Mathf.Abs(DetectTouchMovement.pinchDistanceDelta) > 0)
        {
            // zoom
            pinchAmount = DetectTouchMovement.pinchDistanceDelta;
        }

        if (Mathf.Abs(DetectTouchMovement.turnAngleDelta) > 0)
        {
            // rotate
            Vector3 rotationDeg = Vector3.zero;
            rotationDeg.z = -DetectTouchMovement.turnAngleDelta;
            desiredRotation *= Quaternion.Euler(rotationDeg);
        }

        // not so sure those will work:
        transform.rotation = desiredRotation;
        transform.position += Vector3.forward * pinchAmount;
    }
}
