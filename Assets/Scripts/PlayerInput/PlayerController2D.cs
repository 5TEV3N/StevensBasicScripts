using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController2D : MonoBehaviour
{
    // Self Note Bugs: Player can't move mid air. Player can't double jump (or no option)

    // Please fiddle around with the Rigidbody values that works for you!!!
    private Rigidbody2D rb;             // access the rigidbody2D
    public Sprite playerSprite;         // sprite of the player character

    [Header ("Player Movement")]
    public float playerSpeed;           // speed of the player
    public float valOfVelocity;         // checks how fast the player goes
    public float maxVelocity;           // the max speed of how fast the player goes   

    private float xAxis = 0;            // 1 = right, -1 = left
    private float zAxis = 0;            // 1 = front, -1 back

    [Header ("Jumping")]
    public float playerJumpHeight;      // jump Height 
    public int jumpsAllowed;            // how many jumps you can perform
    public int jumpCounter;             // keeps track of how many legal jumps you performed
    public float jumpRayDistance;       // how long the ray is 
    public LayerMask groundLayerMask;   // checks if it's hitting layer mask = ground

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        if (xAxis != 0)
        {
            PlayerMove(xAxis);
        }
    }

    void Update()
    {
        valOfVelocity = rb.velocity.magnitude;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerJump();
        }
    }

    public void PlayerMove(float xAxis)
    {
        if (xAxis < 0)
        {
            //playerSprite.flipX = true;
            //rb.velocity = -transform.right * playerSpeed;
            if (Mathf.Abs(rb.velocity.x) < maxVelocity)
                rb.AddForce(-transform.right * playerSpeed, ForceMode2D.Impulse);
        }

        if (xAxis > 0)
        {
            //playerSprite.flipX = false;
            //rb.velocity = transform.right * playerSpeed;
            if (Mathf.Abs(rb.velocity.x) < maxVelocity)
                rb.AddForce(transform.right * playerSpeed, ForceMode2D.Impulse);
        }
    }

    public void PlayerJump()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, jumpRayDistance, groundLayerMask))
        {
           rb.AddForce(transform.up * playerJumpHeight, ForceMode2D.Impulse);
        }
    }
    /*
    use this to check if you can double jump. work on later 
    public bool isOnGround()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, jumpRayDistance, groundLayerMask);
    }
    */
}
