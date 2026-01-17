using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeartTrigger : MonoBehaviour
{
    private HealthManager health;
    private AudioManager audio;
    [SerializeField] AudioClip heartSFX;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == GameConstants.TAG_PLAYER)
        {
            health = other.GetComponent<HealthManager>();
            audio = other.GetComponent<AudioManager>();
            Destroy(gameObject);
            audio.AudioPlaySmth(heartSFX);
            health.addHealth(5);
        }
    }
    
}
