using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    Transform target;

    private Transform pointer;

    public Delivery del;
    // Start is called before the first frame update
    void Start()
    {
        del = GameObject.FindGameObjectWithTag(GameConstants.TAG_PLAYER).GetComponent<Delivery>();
        pointer = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        FindTarget();
        if (target)
        {
            Vector3 direction = target.position - pointer.position;
            direction.Normalize();
            pointer.up = direction;
        }
    }


    public void FindTarget()
    {
        if (!del.hasPackage)
        {
            target = GameObject.FindGameObjectWithTag(GameConstants.TAG_PACKAGE).transform;
        }
        else
        {
            target = GameObject.FindGameObjectWithTag(GameConstants.TAG_PERSON).transform;
        }
    }

    
}
