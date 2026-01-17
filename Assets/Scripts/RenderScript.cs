using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderScript : MonoBehaviour
{
    public Delivery del;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        del = GetComponent<Delivery>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ChangeColor()
    {
        if (!del.hasPackage)
        {
            spriteRenderer.color = GameConstants.noPickedColor;
        }
        else
        {
            spriteRenderer.color = GameConstants.pickedColor;
        }
    }
}
