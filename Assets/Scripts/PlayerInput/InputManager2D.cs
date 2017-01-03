using UnityEngine;
using System.Collections;

public class InputManager2D : MonoBehaviour
{
    PlayerController2D playerController2D;       // refference to the playerController2D script

    public Sprite playerSprite;                  // sprite of the player character

    float xAxis = 0;                             // 1 = right, -1 = left
    float zAxis = 0;                             // 1 = front, -1 back
    float mouseXAxis = 0;                        // left or right movement of mouse (camera). Positive numb = right, Negative numb = left
    float mouseYAxis = 0;                        // up or down movement of mouse (camera). Positive numb = up, Negative numb = down.
    bool cameraLock = true;                      // constantly lock the cursor in the center

    void Awake()
    {
        playerController2D = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController2D>();
    }
	
	void FixedUpdate ()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        if (xAxis != 0)
        {
            playerController2D.PlayerMove(xAxis);

            if (xAxis < 0)
            {
                //playerSprite.flipX = true;
            }

            if (xAxis > 0)
            {
                //playerSprite.flipX = false;
            }
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
}
