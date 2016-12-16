using System.Collections;
using UnityEngine;

public class Juice
{
    public void PingPongLerpObjectHorizontal(GameObject object2Lerp , float lengthOfPingPong)
    {
        float pingPongPositionHorizontal = Mathf.PingPong(Time.time, lengthOfPingPong);
        float xPosition = object2Lerp.transform.position.x;
        object2Lerp.transform.position = Vector2.Lerp (object2Lerp.transform.position, new Vector2(xPosition + pingPongPositionHorizontal, object2Lerp.transform.position.y), Time.deltaTime);
    }

    public void LerpObjectVector3 (GameObject object2Lerp , Transform newPos)
    {
        object2Lerp.transform.position = Vector3.Lerp(object2Lerp.transform.position, newPos.transform.position, Time.deltaTime);
    }

    public void LerpObjectVector2(GameObject object2Lerp , Transform newPos)
    {
        object2Lerp.transform.position = Vector3.Lerp(object2Lerp.transform.position, newPos.transform.position, Time.deltaTime);
    }

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

}
