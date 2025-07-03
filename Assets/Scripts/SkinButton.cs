using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinButton : MonoBehaviour
{
    
    [SerializeField] SpriteRenderer ob;

    [SerializeField] Sprite sp1;
    [SerializeField] Sprite sp2;
    [SerializeField] Sprite sp3;
    
    List<Sprite> sprites = new List<Sprite>();
    private int n = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        sprites.Add(sp1);
        sprites.Add(sp2);
        sprites.Add(sp3);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change()
    {
        if (n > 2)
        {
            n = 0;
        }
        ob.sprite = sprites[n];
        n += 1;
        

    }
}
