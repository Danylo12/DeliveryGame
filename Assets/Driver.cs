using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSpeed = 9f;
    [SerializeField] float slowSpeed = 9f;
    [SerializeField] float boostSpeed = 20f;
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth = 100;

    public Health healthbar;

    public GameObject _GameOverPanel;

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
        moveSpeed = slowSpeed;
        TakeDamage(5);
        if (currentHealth <= 0)
        {
            GameOver();
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
        }
        
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);
    }

    public void GameOver()
    {
        Time.timeScale = 0f; // <- It will stop your game time. use it if you need it.
        _GameOverPanel.SetActive(true); // <- Show GameOver Panel
    }

}
