using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothValue;

    void Update()
    {
        Vector3 targetPosition = target.position;
        //add offset
        targetPosition.z = -1;
        Vector3 smoothPosition = Vector3.Lerp(transform.position,targetPosition,smoothValue);
        transform.position = smoothPosition;
    }
    

}
