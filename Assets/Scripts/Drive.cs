using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() // this method is callback
    {
        float steerAmount = Input.GetAxis("Horizontal") * GameConstants.steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * GameConstants.moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount); // Transform - is a class (component from object), Rotate() - is a method from Unity, 0,1f - we got f in the end for making it float
        transform.Translate(0, moveAmount, 0);
    }
}
