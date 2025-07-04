using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeartTrigger : MonoBehaviour
{
    [SerializeField] public GameObject next;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Driver")
        {
            this.gameObject.SetActive(false);
            next.SetActive(true);
        }
    }
}
