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

    public float valOfVelocity;                                      // Checks how fast the player goes
    public float maxVelocity;                                        // The max speed of how fast the player goes

    [Header("Containers")]
    public Rigidbody rb;                                             // Access the rigidbody to move
    public Camera cam;                                               // Acess the Camera of the gameobject
    public Transform camLookAt;

    private Vector3 offset;

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
                    rb.AddForce(transform.right * playerSpeedIntensifier);
                }
            }

            if (xAxis < 0)
            {
                if (Mathf.Abs(valOfVelocity) <= maxVelocity)
                {
                    rb.AddForce(-transform.right * playerSpeedIntensifier);
                }
            }
        }

        if (zAxis != 0)
        {
            if (zAxis > 0)
            {
                if (Mathf.Abs(valOfVelocity) <= maxVelocity)
                {
                    rb.AddForce(transform.forward * playerSpeedIntensifier);
                }
            }

            if (zAxis < 0)
            {
                if (Mathf.Abs(valOfVelocity) <= maxVelocity)
                {
                    rb.AddForce(-transform.forward * playerSpeedIntensifier);
                }
            }
        }
    }

    public void Mouselook(float mouseXAxis, float mouseYAxis)
    {
        //Filter Horizontal input
        if (mouseXAxis != 0)
        {
            //offset = Quaternion.AngleAxis(mouseXAxis, Vector3.up);
            cam.transform.position = camLookAt.position + offset;
            cam.transform.LookAt(gameObject.transform.position);
        }

        //Filter Vertical input
        if (mouseYAxis != 0)
        {

        }
    }
}
