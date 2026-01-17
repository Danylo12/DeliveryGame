using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderScript : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ChangeColor()
    {
        if (!GamePlay.hasPackage)
        {
            spriteRenderer.color = GameConstants.noPickedColor;
        }
        else
        {
            spriteRenderer.color = GameConstants.pickedColor;
        }
    }
}
