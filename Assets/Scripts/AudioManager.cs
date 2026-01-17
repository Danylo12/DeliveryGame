using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{ 
    public void AudioPlaySmth(AudioClip sfx)
    {
        AudioSource.PlayClipAtPoint(sfx, Camera.main.transform.position);
    }
}
