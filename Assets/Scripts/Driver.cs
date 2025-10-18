using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Driver : MonoBehaviour
{
    
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSpeed = 7.5f;
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth = 100;

    public Health healthbar;

    public GameObject _GameOverPanel;
    [SerializeField] FileSavingFoBestScore save;
    

    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);

    }
    // Update is called once per frame
    void Update() // this method is callback
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount); // Transform - is a class (component from object), Rotate() - is a method from Unity, 0,1f - we got f in the end for making it float
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        TakeDamage(3);
        if (currentHealth <= 0)
        {
            GameOver();
        }
        
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);
    }

    public void GameOver()
    {
        save.SavesScore();
        save.ReadFile();
        SceneManager.LoadScene("GameOver");
    }

    public void WinScene()
    {
        save.SavesScore();
        save.ReadFile();
        SceneManager.LoadScene("WinScene");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Heart")
        {
            addHealth(3);
        }
        if (other.tag == "HeartLast")
        {
            addHealth(3);
            other.gameObject.SetActive(false);
        }
    }

    public void addHealth(int num)
    {
        currentHealth += num;
        healthbar.SetHealth(currentHealth);
    }
}
