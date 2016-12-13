using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    // THIS SCRIPT IS FOR THE PLAYER CHARACTER'S MOVEMENT. PLEASE ATTACH THIS SCRIPT AND THE DESIGNATED PLAYERCONTROLLER ONTO THE PLAYER
    // DELETE ANYTHING THAT YOU AREN'T USING

    PlayerController2D playerController2D;       // refference to the playerController2D script
    PlayerController3D playerController3D;       // refference to the playerController3D script

    public Sprite playerSprite;                  // sprite of the player character

    float xAxis = 0;                             // 1 = right, -1 = left
    float zAxis = 0;                             // 1 = front, -1 back
    float mouseXAxis = 0;                        // left or right movement of mouse (camera). Positive numb = right, Negative numb = left
    float mouseYAxis = 0;                        // up or down movement of mouse (camera). Positive numb = up, Negative numb = down.
    bool cameraLock = true;                      // constantly lock the cursor in the center

    void Awake()
    {
        playerController2D = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController2D>();
        playerController3D = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController3D>();
    }
	
	void FixedUpdate ()
    {
        /* SECTION 1. 2DplayerController.

        xAxis = Input.GetAxisRaw("Horizontal");
        if (xAxis != 0)
        {
            playerController2D.PlayerMove(xAxis);

            if (xAxis < 0)
            {
                playerSprite.flipX = true;
            }

            if (xAxis > 0)
            {
                playerSprite.flipX = false;
            }
        }
        
        */

        /* SECTION 2. 3DplayerController.
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        mouseXAxis = Input.GetAxis("Mouse X");
        mouseYAxis = Input.GetAxis("Mouse Y");

        xAxis = Input.GetAxisRaw("Horizontal");
        zAxis = Input.GetAxisRaw("Vertical");

        if (mouseXAxis != 0 || mouseYAxis != 0)
        {
            playerController3D.Mouselook(mouseXAxis, mouseYAxis);
        }

        if (xAxis != 0 || zAxis != 0)
        {
            playerController3D.PlayerMove(xAxis, zAxis);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cameraLock = true;

            if (cameraLock == true)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                cameraLock = false;
            }
        }
        
        */
    }
}
