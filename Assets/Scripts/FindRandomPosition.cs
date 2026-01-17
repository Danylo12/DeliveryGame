using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class FindRandomPosition 
{
    public static  Vector3 RandomPosition(GameObject WorldObjectsList)
    {
        
        int choice = Random.Range( 0, WorldObjectsList.transform.childCount);
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
