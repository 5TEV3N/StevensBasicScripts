using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController2D : MonoBehaviour
{
    public float playerSpeed;           // speed of the player
    public float playerJumpHeight;      // jump Height 
    public bool isGrounded;             // checks if grounded
    public float valOfVelocity;         // checks how fast the player goes
    public float maxVelocity;           // the max speed of how fast the player goes   

    private Rigidbody2D rb;             // access the rigidbody2D

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        VelocityCheck();
    }

    public void VelocityCheck()
    {
        valOfVelocity = rb.velocity.magnitude;
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
    }

    public void PlayerMove(float xAxis)
    {
        if (xAxis != 0)
        {
            if (xAxis > 0)
            {
                rb.AddForce(transform.right * playerSpeed, ForceMode2D.Impulse);    
            }

            if (xAxis < 0)
            {          
                rb.AddForce(-transform.right * playerSpeed, ForceMode2D.Impulse);
            }
        }
    }
    public void PlayerJump()
    {

    }
}
