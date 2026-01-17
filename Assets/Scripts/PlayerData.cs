using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


public class PlayerData
{
    public List<Vector3> HeartPositions = new List<Vector3>();
    public Vector3 PackagePosition;
    public int Health;
    public int Score;
    public Vector3 position;
    public Quaternion rotation;
}
public static class SaveManager 
{
    static PlayerData data;
    public static void SaveGame(PlayerData data)
    {
        string json = JsonUtility.ToJson(data, true);
        
        File.WriteAllText(GameConstants.path, json);
        
        Debug.Log("Saved to: " + GameConstants.path);
    }
    
    public static PlayerData RestorePLayerData()
    {

        if (File.Exists(GameConstants.path))
        {
            string json = File.ReadAllText(GameConstants.path);

            Debug.Log("Returned from: " + GameConstants.path);

            return JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            Debug.LogError("Save file not found!");
            return null;
        }
        
        
    }

    public static void CreateObjectsFromData(PlayerData data)
    {
        if (data != null)
        {

            GameObject[] heartobjs = GameObject.FindGameObjectsWithTag(GameConstants.TAG_HEART);
            for(int i = 0; i < heartobjs.Length; i++)
            {
                heartobjs[i].transform.position = data.HeartPositions[i];
            }
            GameObject packageObj = GameObject.FindWithTag(GameConstants.TAG_PACKAGE); 
            if (packageObj != null)
            {
                packageObj.transform.position = data.PackagePosition;
            }
            GameObject playerCar = GameObject.FindWithTag(GameConstants.TAG_PLAYER); 
            if (playerCar != null)
            {
                playerCar.transform.position = data.position;
                playerCar.transform.rotation = data.rotation;
                Debug.Log(data.Health);
                playerCar.GetComponent<HealthManager>().currentHealth = data.Health;
                Debug.Log(playerCar.GetComponent<HealthManager>().currentHealth);
                Debug.Log("Car moved to saved position.");
            }

            GameObject progres = GameObject.FindWithTag(GameConstants.TAG_PROGRESS);
            if (progres != null)
            {
                Debug.Log(data.Score);
                progres.GetComponent<Progress>().currentProgress = data.Score;
                Debug.Log(progres.GetComponent<Progress>().currentProgress);
            }


        }
    }
    
    public static PlayerData SetDefaulData(){ 
        data = new PlayerData();
        data.Health = 100;
        data.Score = 0;
        data.position = new Vector3(4.9f, 1.4f, -2f);
        data.rotation = new Quaternion (0,0,0,1);
        data.HeartPositions.Add(new Vector3(3.26f, 1.4f, -2f));
        data.PackagePosition = new Vector3(16.22f, 4.1f, -2f);
        return data;

    }

    public static PlayerData SetRandomData()
    {
        data = new PlayerData();
        data.Health = 30;
        data.Score = 7;
        data.position = new Vector3(4.46f, 15.37f, -2f);
        data.rotation = new Quaternion (0,0,90,0);
        data.HeartPositions.Add(new Vector3(4.46f, 19.37f, -2f));
        data.PackagePosition = new Vector3(4.46f, 22.37f, -2f);
        return data;
    }
}

