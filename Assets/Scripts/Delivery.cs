using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class Delivery : MonoBehaviour
{
    public bool hasPackage;
    public Progress progress;
    [SerializeField] GameObject WorldObjectsList;

    
    [SerializeField] GameObject Person;
    [SerializeField] GameObject Package;
    [SerializeField] GameObject Heart;

    [SerializeField] AudioClip PackageSFX;
    [SerializeField] AudioClip PersonSFX;

    public RenderScript driverRender;

    private void Start()
    {
        driverRender = GetComponent<RenderScript>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == GameConstants.TAG_PACKAGE && !hasPackage)
        {
            hasPackage = true;
            driverRender.ChangeColor();
            other.transform.position = FindRandomPosition.RandomPosition(WorldObjectsList);
            Package = other.gameObject;
            other.gameObject.SetActive(false);
            
            Person.SetActive(true);
            Instantiate(Heart, FindRandomPosition.RandomPosition(WorldObjectsList), Quaternion.identity);
            AudioSource.PlayClipAtPoint(PackageSFX, Camera.main.transform.position);
            

        }

        if (other.tag == GameConstants.TAG_PERSON && hasPackage)
        {
            progress.addProgress();
            hasPackage = false;
            driverRender.ChangeColor();
            other.transform.position = FindRandomPosition.RandomPosition(WorldObjectsList);
            Person = other.gameObject;
            other.gameObject.SetActive(false);
            Package.gameObject.SetActive(true);
            AudioSource.PlayClipAtPoint(PersonSFX, Camera.main.transform.position);
            
        }



    }
    
}