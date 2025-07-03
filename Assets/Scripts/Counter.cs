using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] Canvas c1;
    [SerializeField] Canvas c2;
    [SerializeField] Canvas c3;
    [SerializeField] Canvas c4;
    private List<Canvas> c = new List<Canvas>();
    private int n = 0;
    
    void Start()
    {
        c.Add(c1);
        c.Add(c2);
        c.Add(c3);
        c.Add(c4);
        
        
    }

    public void NextCanvas()
    {
        c[n].gameObject.SetActive(false);
        n += 1;
        c[n].gameObject.SetActive(true);
    }

    public void PreviousCanvas()
    {
        c[n].gameObject.SetActive(false);
        n -= 1;
        c[n].gameObject.SetActive(true);
        
    }
}
