using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;

    private void Awake()
    {
        if (levelManager == null)
        {
            DontDestroyOnLoad(gameObject);
            levelManager = this;
        }
        else if (levelManager != this)
        {
            Destroy(gameObject);
        }
    }

}
