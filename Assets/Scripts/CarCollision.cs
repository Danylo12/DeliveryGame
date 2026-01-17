using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour
{
    public HealthManager health;

    public DeleteFile delete;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HealthManager>();
        delete = GetComponent<DeleteFile>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    void OnCollisionEnter2D(Collision2D other)
    {
        health.TakeDamage(3);
        if (health.currentHealth <= 0)
        {
            delete.Delete();
        }
        
    }
}
