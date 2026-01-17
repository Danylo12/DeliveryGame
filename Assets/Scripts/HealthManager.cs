using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Health healt;
    public int currentHealth;
    private AudioManager audio;
    [SerializeField] AudioClip hitSFX;
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
        audio.AudioPlaySmth(hitSFX);
        healt.SetHealth(currentHealth);
    }
    
    public void addHealth(int num)
    {
        currentHealth += num;
        healt.SetHealth(currentHealth);
    }
}
