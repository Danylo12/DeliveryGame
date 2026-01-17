using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Health healt;
    public int currentHealth;
    public AudioManager audio;
    void Start()
    {
        healt = GameObject.FindGameObjectWithTag(GameConstants.TAG_HEALTH).GetComponent<Health>();
        healt.SetMaxHealth(GameConstants.maxHealth);
        healt.SetHealth(currentHealth);
        audio = GetComponent<AudioManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void TakeDamage(int damage)
    {
        
        currentHealth -= damage;
        audio.AudioHit();
        healt.SetHealth(currentHealth);
    }
    
    public void addHealth(int num)
    {
        currentHealth += num;
        healt.SetHealth(currentHealth);
    }
}
