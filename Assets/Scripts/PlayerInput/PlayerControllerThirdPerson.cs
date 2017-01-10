using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerThirdPerson : MonoBehaviour
{

    InputManagerThirdPerson inputManagerThirdPerson;

    [Header("Values")]
    public float mouseSensitivity = 1;                               // Mouse sensitivity
    public float jumpHeightIntensifier = 1;                          // How far i can jump
    public float playerSpeedIntensifier = 1;                         // We can controll the speed of the player here.
    public float upDownRange = 90.0f;                                // How far i can look up or down.

    public float valOfVelocity;                                      // Checks how fast the player goes
    public float maxVelocity;                                        // The max speed of how fast the player goes
    public float cameraDistance = 10.0f;                             // Distance between the camera and the player

    [Header("Containers")]
    public Rigidbody rb;                                             // Access the rigidbody to move
    public Camera cam;                                               // Acess the Camera of the gameobject
    public Transform camLookAt;
    public Transform camTransform;

    private float currentX;
    private float currentY;

    void Awake()
    {
        inputManagerThirdPerson = GameObject.FindGameObjectWithTag("Player").GetComponent<InputManagerThirdPerson>();
    }

    void Update()
    {
        valOfVelocity = rb.velocity.magnitude;
    }

    public void PlayerMove(float xAxis, float zAxis)
    {

        if (xAxis != 0)
        {
            if (xAxis > 0)
            {
                if (Mathf.Abs(valOfVelocity) <= maxVelocity)
                {
                    rb.AddForce(transform.right + cam.transform.forward * playerSpeedIntensifier);
                }
            }

            if (xAxis < 0)
            {
                if (Mathf.Abs(valOfVelocity) <= maxVelocity)
                {
                    rb.AddForce(-transform.right + cam.transform.forward * playerSpeedIntensifier);
                }
            }
        }

        if (zAxis != 0)
        {
            if (zAxis > 0)
            {
                if (Mathf.Abs(valOfVelocity) <= maxVelocity)
                {
                    rb.AddForce(transform.forward + cam.transform.forward * playerSpeedIntensifier);
                }
            }

            if (zAxis < 0)
            {
                if (Mathf.Abs(valOfVelocity) <= maxVelocity)
                {
                    rb.AddForce(-transform.forward + cam.transform.forward * playerSpeedIntensifier);
                }
            }
        }
    }

    public void Mouselook(float mouseXAxis, float mouseYAxis)
    {
        currentX += mouseXAxis;
        currentY += mouseYAxis;
        currentY = Mathf.Clamp(currentY, -upDownRange, upDownRange);
        //https://www.youtube.com/watch?v=Ta7v27yySKs
        Vector3 dir = new Vector3(0, 0, -cameraDistance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = camLookAt.position + rotation * dir;
        camTransform.LookAt(camLookAt.position);
    }
}
