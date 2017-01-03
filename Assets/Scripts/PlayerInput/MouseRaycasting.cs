using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRaycasting : MonoBehaviour
{
    public RaycastHit mouseHit;
    private Ray mouseRay;
    private Vector3 mousePosition;
    public Camera playerCamera;

    void Update()
    {
        mousePosition = playerCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseRay = playerCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawLine(mousePosition, mouseRay.direction,Color.magenta);
    }
}
