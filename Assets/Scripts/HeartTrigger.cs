using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeartTrigger : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Driver")
        {
            Destroy(gameObject);
        }
    }
}
