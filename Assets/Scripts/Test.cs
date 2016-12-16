using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Juice juice = new Juice();

    void Update()
    {
        juice.PingPongLerpObjectHorizontal(gameObject, 1f);
    }
}
