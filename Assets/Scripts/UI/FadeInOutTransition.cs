using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOutTransition : MonoBehaviour
{
    // Attach a panel with no source image on your UI. Then attach that image into the fadeImg
    public Image fadeImg;
    public bool activatedFading;
    public bool fadeOut;

    public float smooth;
    private Color black;
    private Color clear;

    private void Awake()
    {
        black = Color.black;
        clear = Color.clear;
    }

    private void Update()
    {
        if (activatedFading == true)
        {
            if (fadeOut == true)
            {
                fadeImg.color = Color.Lerp(fadeImg.color, Color.clear, Time.deltaTime * smooth);
            }
            else
            {
                fadeImg.color = Color.Lerp(fadeImg.color, Color.black, Time.deltaTime * smooth);
            }
        }
        else
        {
            fadeImg.color = Color.clear;
        }
    }

}
