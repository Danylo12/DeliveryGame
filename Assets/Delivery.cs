using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 pickedColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPickedColor = new Color32(0, 0, 0, 0);

    bool hasPackage;

    SpriteRenderer spriteRenderer;
 
    List<GameObject> gameObjects = new List<GameObject>();
    List<GameObject> packages = new List<GameObject>();

    [SerializeField] GameObject g;
    [SerializeField] GameObject g2;
    [SerializeField] GameObject g3;
    [SerializeField] GameObject g4;

    [SerializeField] GameObject p;
    [SerializeField] GameObject p2;
    [SerializeField] GameObject p3;

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
        packages.Add(p);
        packages.Add(p2);
        packages.Add(p3);
        currentProgress = minProgress;
        progress.SetMinProgress(minProgress);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("You picked up a package");
            hasPackage = true;
            spriteRenderer.color = pickedColor;
            other.gameObject.SetActive(false);
            gameObjects[n].SetActive(true);
            n = n + 1;

        }
        if (other.tag == "Person" && hasPackage)
        {
            addProgress();
            if (currentProgress == 4)
            {
                driver.GameOver();
            }
            hasPackage = false;
            Debug.Log("Package was delivered");
            spriteRenderer.color = noPickedColor;
            other.gameObject.SetActive(false);
            packages[count].SetActive(true);
            count = count + 1;

            
        }

    }

    public void addProgress()
    {
        currentProgress = currentProgress + 1;
        progress.SetProgress(currentProgress);
    }
}
