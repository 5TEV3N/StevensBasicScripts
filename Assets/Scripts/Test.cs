using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    BasicJuice juice = new BasicJuice();
    BasicTimer timer = new BasicTimer();
    BasicPlayer player1 = new BasicPlayer();
    
    public Transform newPosition;
    public float testTimer = 5;

    void Start()
    {
        timer.timerLeft = testTimer;
    }

    void Update()
    {
        juice.GameObjectLerping("LerpObjectVector2", gameObject, newPosition);

        timer.CountDownFrom(testTimer);

        print(timer.timerLeft);

        if (timer.timerLeft == 0)
        {
            print("Time's up!");
        }
    }
}
