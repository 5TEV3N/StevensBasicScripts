using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerThirdPerson : MonoBehaviour
{

    PlayerControllerThirdPerson playerControllerThirdPerson;       // refference to the playerController3D script

    public Sprite playerSprite;                                    // sprite of the player character

    float xAxis = 0;                                               // 1 = right, -1 = left
    float zAxis = 0;                                               // 1 = front, -1 back
    float mouseXAxis = 0;                                          // left or right movement of mouse (camera). Positive numb = right, Negative numb = left
    float mouseYAxis = 0;                                          // up or down movement of mouse (camera). Positive numb = up, Negative numb = down.
    bool cameraLock = true;                                        // constantly lock the cursor in the center

    void Awake()
    {
        playerControllerThirdPerson = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerThirdPerson>();
    }

    void FixedUpdate()
    {

        mouseXAxis = Input.GetAxis("Mouse X");
        mouseYAxis = Input.GetAxis("Mouse Y");

        xAxis = Input.GetAxisRaw("Horizontal");
        zAxis = Input.GetAxisRaw("Vertical");

        if (mouseXAxis != 0 || mouseYAxis != 0)
        {
            playerControllerThirdPerson.Mouselook(mouseXAxis, mouseYAxis);
        }

        if (xAxis != 0 || zAxis != 0)
        {
            playerControllerThirdPerson.PlayerMove(xAxis, zAxis);
        }

    }
}
