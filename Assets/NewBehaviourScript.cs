using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Spawner spawn = new Spawner();
    public GameObject bullet;

    private void Start()
    {
        InvokeRepeating("ShootingTheBullet", 1.0f, 0.1f);
    }
    private void ShootingTheBullet()
    {
        spawn.SpawnObjectAtSpot(gameObject.transform, bullet);
    }
}
