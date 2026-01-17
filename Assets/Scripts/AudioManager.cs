using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip hitSFX;
    [SerializeField] AudioClip heartSFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AudioHealth()
    {
        AudioSource.PlayClipAtPoint(heartSFX, Camera.main.transform.position);
    }

    public void AudioHit()
    {
        AudioSource.PlayClipAtPoint(hitSFX, Camera.main.transform.position);
    }
}
