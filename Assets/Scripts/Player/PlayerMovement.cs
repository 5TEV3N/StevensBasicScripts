using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    [Header ("Player")]
    public Sprite playerSprite;

    [Header("Values")]
    public bool firstPersonController;
    public float playerSpeed;
    public float currentVelocity;
    public float maxVelocity;

    [Header ("")]
    public float playerJumpHeight;               // jump Height 
    public float maxTerminalVelocity;            // max speed of how fast the player falls
    public int jumpsAllowed;                     // how many jumps you can perform
    public int jumpCounter;                      // keeps track of how many legal jumps you performed
    public float jumpRayDistance;                // how long the ray is 

    private Rigidbody rb;
    private float xAxis = 0f;
    private float zAxis = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        currentVelocity = rb.velocity.magnitude;
    }

    private void FixedUpdate()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        zAxis = Input.GetAxisRaw("Vertical");

        if (firstPersonController == false)
        {
            if (xAxis != 0)
            {
                PlayerMove(xAxis, 0, firstPersonController);
            }
        }
        else if (xAxis != 0 || zAxis != 0)
        {
            PlayerMove(xAxis, zAxis, firstPersonController);
        }
    }

    public void PlayerMove(float xAxis, float zAxis, bool FirstPerson)
    {
        if (FirstPerson == false)
        {
            if (xAxis < 0)
            {
                //playerSprite.flipX = true;
                if (Mathf.Abs(currentVelocity) <= maxVelocity)
                {
                    rb.AddForce(-transform.right * playerSpeed, ForceMode.Impulse);
                }
            }
            if (xAxis > 0)
            {
                //playerSprite.flipX = false;
                if (Mathf.Abs(currentVelocity) <= maxVelocity)
                {
                    rb.AddForce(transform.right * playerSpeed, ForceMode.Impulse);
                }
            }
        }
        else
        {
            if (xAxis < 0)
            {
                //playerSprite.flipX = true;
                if (Mathf.Abs(currentVelocity) <= maxVelocity)
                {
                    rb.AddForce(-transform.right * playerSpeed, ForceMode.Impulse);
                }
            }
            if (xAxis > 0)
            {
                //playerSprite.flipX = false;
                if (Mathf.Abs(currentVelocity) <= maxVelocity)
                {
                    rb.AddForce(transform.right * playerSpeed, ForceMode.Impulse);
                }
            }

            if (zAxis < 0)
            {
                if (Mathf.Abs(currentVelocity) <= maxVelocity)
                {
                    rb.AddForce(-transform.forward * playerSpeed, ForceMode.Impulse);
                }
            }
            if (zAxis > 0)
            {
                if (Mathf.Abs(currentVelocity) <= maxVelocity)
                {
                    rb.AddForce(transform.forward * playerSpeed, ForceMode.Impulse);
                }
            }
        }
    }
}
