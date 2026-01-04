using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 pickedColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPickedColor = new Color32(0, 0, 0, 0);

    [SerializeField] Transform pointer;
    [SerializeField] Transform target;

    bool hasPackage;

    SpriteRenderer spriteRenderer;

    List<GameObject> gameObjects = new List<GameObject>();
    List<GameObject> packages = new List<GameObject>();
    List<GameObject> Hearts = new List<GameObject>();

    [SerializeField] GameObject g;
    [SerializeField] GameObject g2;
    [SerializeField] GameObject g3;
    [SerializeField] GameObject g4;
    [SerializeField] GameObject g5;
    [SerializeField] GameObject g6;
    [SerializeField] GameObject g7;
    [SerializeField] GameObject g8;

    [SerializeField] GameObject p;
    [SerializeField] GameObject p2;
    [SerializeField] GameObject p3;
    [SerializeField] GameObject p4;
    [SerializeField] GameObject p5;
    [SerializeField] GameObject p6;
    [SerializeField] GameObject p7;
    
    [SerializeField] GameObject h;
    [SerializeField] GameObject h2;
    [SerializeField] GameObject h3;
    [SerializeField] GameObject h4;
    [SerializeField] GameObject h5;
    [SerializeField] GameObject h6;
    [SerializeField] GameObject h7;
    

    int n = 0;
    int count = 0;

    public Progress progress;
    [SerializeField] int minProgress;
    [SerializeField] int currentProgress;

    public Driver driver;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameObjects.Add(g);
        gameObjects.Add(g2);
        gameObjects.Add(g3);
        gameObjects.Add(g4);
        gameObjects.Add(g5);
        gameObjects.Add(g6);
        gameObjects.Add(g7);
        gameObjects.Add(g8);
        
        packages.Add(p);
        packages.Add(p2);
        packages.Add(p3);
        packages.Add(p4);
        packages.Add(p5);
        packages.Add(p6);
        packages.Add(p7);
        
        Hearts.Add(h);
        Hearts.Add(h2);
        Hearts.Add(h3);
        Hearts.Add(h4);
        Hearts.Add(h5);
        Hearts.Add(h6);
        Hearts.Add(h7);
        currentProgress = minProgress;
        progress.SetMinProgress(minProgress);

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
        if (other.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            spriteRenderer.color = pickedColor;
            other.gameObject.SetActive(false);
            gameObjects[n].SetActive(true);
            Hearts[n].SetActive(true);
            target = gameObjects[n].transform;
            n = n + 1;

        }

        if (other.tag == "Person" && hasPackage)
        {
            addProgress();
            if (currentProgress == 8)
            {
                driver.WinScene();
            }

            hasPackage = false;
            spriteRenderer.color = noPickedColor;
            other.gameObject.SetActive(false);
            packages[count].SetActive(true);
            target = packages[count].transform;
            count = count + 1;
            
        }



    }

    public void addProgress()
    {
        currentProgress++;
        progress.SetProgress(currentProgress);
    }
}