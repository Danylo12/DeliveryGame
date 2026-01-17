using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class Delivery : MonoBehaviour
{
    [SerializeField] Transform pointer;
    [SerializeField] Transform target;

    bool hasPackage;

    SpriteRenderer spriteRenderer;

    
    [SerializeField] GameObject Person;
    [SerializeField] GameObject Package;
    [SerializeField] GameObject Heart;
    

    public Progress progress;
    [SerializeField] public int currentProgress;

    [SerializeField] AudioClip PackageSFX;
    [SerializeField] AudioClip PersonSFX;

    [SerializeField] GameObject WorldObjectsList;
    

    public Driver driver;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        progress.SetMinProgress(GameConstants.minProgress);
        progress.SetProgress(currentProgress);

    }

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - pointer.position;
            direction.Normalize();
            pointer.up = direction;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == GameConstants.TAG_PACKAGE && !hasPackage)
        {
            hasPackage = true;
            spriteRenderer.color = GameConstants.pickedColor;
            other.transform.position = RandomPosition();
            Package = other.gameObject;
            other.gameObject.SetActive(false);
            
            Person.SetActive(true);
            Instantiate(Heart, RandomPosition(), Quaternion.identity);
            target = Person.transform;
            AudioSource.PlayClipAtPoint(PackageSFX, Camera.main.transform.position);
            

        }

        if (other.tag == GameConstants.TAG_PERSON && hasPackage)
        {
            addProgress();
            if (currentProgress == 8)
            {
                driver.WinScene();
            }

            hasPackage = false;
            spriteRenderer.color = GameConstants.noPickedColor;
            other.transform.position = RandomPosition();
            Person = other.gameObject;
            other.gameObject.SetActive(false);
            target = Package.transform;
            Package.gameObject.SetActive(true);
            AudioSource.PlayClipAtPoint(PersonSFX, Camera.main.transform.position);
            
        }



    }

    public void addProgress()
    {
        currentProgress++;
        progress.SetProgress(currentProgress);
    }

    public Vector3 RandomPosition()
    {
        int choice = UnityEngine.Random.Range( 0, WorldObjectsList.transform.childCount);
        Transform randomChild = WorldObjectsList.transform.GetChild(choice);
        
        while (randomChild.gameObject.tag != GameConstants.TAG_ROAD)
        {
            choice = UnityEngine.Random.Range( 0, WorldObjectsList.transform.childCount);
            randomChild = WorldObjectsList.transform.GetChild(choice);
        }

        Vector3 position = new Vector3(randomChild.position.x, randomChild.position.y, -2) ;

        return position;

    }
}