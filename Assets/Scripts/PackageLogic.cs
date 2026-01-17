using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageLogic : MonoBehaviour
{
    [SerializeField] AudioClip packageSFX;
    [SerializeField] public GameObject person;
    [SerializeField] public GameObject Heart;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == GameConstants.TAG_PLAYER)
        {
            GamePlay.SmthHappened(gameObject, packageSFX);
            GamePlay.SetActiveSmth(person);
            Instantiate(Heart, FindRandomPosition.RandomPosition(), Quaternion.identity);
        }
    }
}
