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

    [Header("")]
    public bool jumpingAllowed;
    public KeyCode jumpKey;
    public LayerMask groundLayerMask;

    [Header("")]
    public float playerJumpHeight;               
    public float jumpRayDistance = 1f;           // how long the ray is 
    //public float maxTerminalVelocity;            // max speed of how fast the player falls
    //public int jumpsAllowed = 1;                 // how many jumps you can perform
    //public int jumpCounter;                      // keeps track of how many legal jumps you performed

    private Rigidbody rb;
    private float xAxis = 0f;
    private float zAxis = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        currentVelocity = rb.velocity.magnitude;
        Debug.DrawRay(transform.position, Vector3.down * jumpRayDistance, Color.magenta);

        xAxis = Input.GetAxisRaw("Horizontal");
        zAxis = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(jumpKey))
        {
            if (jumpingAllowed == true)
            {
                PlayerJump();
            }
            else { Debug.Log("Debug : Jumping is disabled, please enable it on the inspector."); }
        }

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
                if (Mathf.Abs(currentVelocity) <= maxVelocity)
                {
                    rb.AddForce(-transform.right * playerSpeed, ForceMode.Impulse);
                }
            }
            if (xAxis > 0)
            {
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

    public void PlayerJump()
    {
        if (isOnGround() == true)
        {
            rb.AddForce(transform.up * playerJumpHeight, ForceMode.Impulse);
        }
    }

    public bool isOnGround()
   {
       return Physics.Raycast(transform.position, Vector3.down, jumpRayDistance, groundLayerMask);
   }


}
