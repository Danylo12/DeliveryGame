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
        
        string path = Path.Combine(Application.persistentDataPath, "Save.json");
        
        File.WriteAllText(path, json);
        
        Debug.Log("Saved to: " + path);
    }
    
    public static PlayerData RestorePLayerData()
    {
        string path = Path.Combine(Application.persistentDataPath, "Save.json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            Debug.Log("Returned from: " + path);

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

            GameObject[] heartobjs = GameObject.FindGameObjectsWithTag("Heart");
            for(int i = 0; i < heartobjs.Length; i++)
            {
                heartobjs[i].transform.position = data.HeartPositions[i];
            }
            GameObject packageObj = GameObject.FindWithTag("Package"); 
            if (packageObj != null)
            {
                packageObj.transform.position = data.PackagePosition;
            }
            GameObject playerCar = GameObject.FindWithTag("Driver"); 
            if (playerCar != null)
            {
                playerCar.transform.position = data.position;
                playerCar.transform.rotation = data.rotation;
                Debug.Log(data.Health);
                playerCar.GetComponent<Driver>().currentHealth = data.Health;
                Debug.Log(playerCar.GetComponent<Driver>().currentHealth);
                Debug.Log(data.Score);
                playerCar.GetComponent<Delivery>().currentProgress = data.Score;
                Debug.Log(playerCar.GetComponent<Delivery>().currentProgress);
                Debug.Log("Car moved to saved position.");
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
        data.Score = 5;
        data.position = new Vector3(4.46f, 15.37f, -2f);
        data.rotation = new Quaternion (0,0,90,0);
        data.HeartPositions.Add(new Vector3(4.46f, 19.37f, -2f));
        data.PackagePosition = new Vector3(4.46f, 22.37f, -2f);
        return data;
    }
}

