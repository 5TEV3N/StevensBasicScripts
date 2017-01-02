using System.Collections;
using UnityEngine;

public class BasicJuice
{
    public void LerpMusic(AudioSource sound, float newSoundVolume, bool fadeOut)
    {
        if (fadeOut == true)
        {
            sound.volume = Mathf.Lerp(sound.volume, 0f, Time.deltaTime);
        }
        if (fadeOut == false)
        {
            sound.volume = Mathf.Lerp(sound.volume, newSoundVolume, Time.deltaTime);
        }
    }

    public void GameObjectLerping(string command, GameObject object2Lerp, Transform newPos)
    {
        switch (command)
        {
            case "RotationLerp":
                object2Lerp.transform.rotation = Quaternion.Lerp(object2Lerp.transform.rotation, newPos.transform.rotation, Time.deltaTime);
                break;
            case "LerpObjectVector3":
                object2Lerp.transform.position = Vector3.Lerp(object2Lerp.transform.position, newPos.transform.position, Time.deltaTime);
                break;
            case "LerpObjectVector2":
                object2Lerp.transform.position = Vector2.Lerp(object2Lerp.transform.position, newPos.transform.position, Time.deltaTime);
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }
}
