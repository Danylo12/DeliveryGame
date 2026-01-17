using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Driver : MonoBehaviour
{
    
    [SerializeField] public int currentHealth;

    public Health healthbar;

    [SerializeField] AudioClip hitSFX;
    [SerializeField] AudioClip heartSFX;


    private void Start()
    {
        healthbar.SetMaxHealth(GameConstants.maxHealth);
        healthbar.SetHealth(currentHealth);

    }
    // Update is called once per frame
    void Update() // this method is callback
    {
        float steerAmount = Input.GetAxis("Horizontal") * GameConstants.steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * GameConstants.moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount); // Transform - is a class (component from object), Rotate() - is a method from Unity, 0,1f - we got f in the end for making it float
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        TakeDamage(3);
        if (currentHealth <= 0)
        {
            string playerPath = Path.Combine(Application.persistentDataPath, GameConstants.SAVE_FILE);
            
            if (File.Exists(playerPath))
            {
                File.Delete(playerPath);
                Debug.Log("Deleted: " + playerPath);
            }

            GameOver();
        }
        
    }

    void TakeDamage(int damage)
    {
        
        currentHealth -= damage;
        AudioSource.PlayClipAtPoint(hitSFX, Camera.main.transform.position);
        healthbar.SetHealth(currentHealth);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(GameConstants.SCENE_GAMEOVER);
    }

    public void WinScene()
    {
        SceneManager.LoadScene(GameConstants.SCENE_WIN);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == GameConstants.TAG_HEART)
        {
            AudioSource.PlayClipAtPoint(heartSFX, Camera.main.transform.position);
            addHealth(5);
        }
    }

    public void addHealth(int num)
    {
        currentHealth += num;
        healthbar.SetHealth(currentHealth);
    }
}
