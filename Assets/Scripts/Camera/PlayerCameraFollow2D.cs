using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraFollow2D : MonoBehaviour
{
    public Transform lookAt;                             // The transform of what you want to look at
    public Vector3 offset;                               // How off centered the camera is
    public float smoothSpeed;                            // How smooth the camera follows the lookAt transform

    private Vector3 desiredPosition;                     // Holds the value of what youre looking at and what kind of offset you have

    void Update()
    {
        desiredPosition = lookAt.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }
}
