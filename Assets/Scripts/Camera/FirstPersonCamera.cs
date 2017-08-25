using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    private Camera cam;                                              // Reff to the camera
    public GameObject player;                                        // Tag your player before using this script!!!!

    public float mouseSensitivity;
    public float upDownRange = 90.0f;                                // How far i can look up or down.
    private float verticalRotation = 0;                              // Contains the MouseYAxis
    private float mouseXAxis;
    private float mouseYAxis;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");
        this.transform.SetParent(player.transform);
        this.transform.position = player.transform.position;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        mouseXAxis = Input.GetAxis("Mouse X");
        mouseYAxis = Input.GetAxis("Mouse Y");

        if (mouseXAxis != 0 || mouseYAxis != 0)
        {
            Mouselook(mouseXAxis, mouseYAxis);
        }
    }

    public void Mouselook(float mouseXAxis, float mouseYAxis)
    {
        //Filter Horizontal input
        if (mouseXAxis != 0)
        {
            player.transform.Rotate(new Vector3(0, mouseXAxis, 0));

        }

        //Filter Vertical input
        if (mouseYAxis != 0)
        {
            verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
            cam.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        }
    }
}
