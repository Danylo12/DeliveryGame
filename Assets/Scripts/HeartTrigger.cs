using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeartTrigger : MonoBehaviour
{
    public HealthManager health;
    public AudioManager audio;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == GameConstants.TAG_PLAYER)
        {
            health = other.GetComponent<HealthManager>();
            audio = other.GetComponent<AudioManager>();
            Destroy(gameObject);
            audio.AudioHealth();
            health.addHealth(5);
        }
    }
    
}
