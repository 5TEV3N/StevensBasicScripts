using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof (Camera))]
public class PlayerRaycast : MonoBehaviour
{
    // MUST BE ATTACHED TO THE CAMERA
    // MAKE SURE THAT THE OBJECT THAT CAN BE INTEACTED WITH IS WITHIN THIS LAYER MASK.

    public LayerMask interactiveMask;
    public float mouseRayDistance;
    public RaycastHit mouseHit;
    public Ray mouseRay;
    public GameObject hit;
    private Vector3 mousePosition;  //Relative to camera's position
        
    void Update()
    {
        DebugRaycast();
        canIntarctWithThisObject();
    }

    void DebugRaycast()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(mousePosition, mouseRay.direction * mouseRayDistance, Color.green);
    }

    public bool canIntarctWithThisObject()
    {
        return Physics.Raycast(mouseRay, out mouseHit, mouseRayDistance, interactiveMask);
    }

    public GameObject hitObject()
    {
        hit = mouseHit.transform.gameObject;
        return hit;
    }

    public Vector3 hitObjectTransform()
    {
        return hit.transform.position;
    }
}
