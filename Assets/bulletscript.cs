using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour {
    Rigidbody rb;
	// Update is called once per frame
	void Update ()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up, ForceMode.Impulse);
	}
}
