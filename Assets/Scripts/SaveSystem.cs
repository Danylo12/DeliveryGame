using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Localization.Plugins.XLIFF.V20;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance;
    PlayerData data;
    CarData car;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    
    public Button SaveButton;
    public Button RestoreButton;
    // Start is called before the first frame update
    void Start()
    {
        if (SaveButton != null) DebugForButton(SaveButton, ButtonSavePressed);
        if (RestoreButton != null) DebugForButton(RestoreButton, ButtonRestorePressed);
        //Default Data
        SetDefaulData();
        

    }


    public void ButtonRestorePressed()
    {
        data = RestorePLayerData();
        car = RestoreCarData();
        if (data != null && car != null)
        {
            RestoreGameScene();
        }
        else
        {
            SetDefaulData();
        }
    }

    public void ButtonSavePressed()
    {
        SetRandomData();
        SaveGame(data, car);
    }
    public void RestoreGameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene loaded! Searching for objects to restore...");

        GameObject btnSaveObj = GameObject.Find("Btn_Save"); 
        if (btnSaveObj != null)
        {
            SaveButton = btnSaveObj.GetComponent<Button>();
            DebugForButton(SaveButton, ButtonSavePressed);
        }

        GameObject btnRestoreObj = GameObject.Find("Btn_Restore"); 
        if (btnRestoreObj != null)
        {
            RestoreButton = btnRestoreObj.GetComponent<Button>();
            DebugForButton(RestoreButton, ButtonRestorePressed);
        }
        if (car != null) 
        {
            GameObject playerCar = GameObject.FindWithTag("Driver"); 
            if (playerCar != null)
            {
                playerCar.transform.position = car.position;
                playerCar.transform.rotation = car.rotation;
                Debug.Log(car.Health);
                playerCar.GetComponent<Driver>().currentHealth = car.Health;
                Debug.Log(playerCar.GetComponent<Driver>().currentHealth);
                Debug.Log(car.Score);
                playerCar.GetComponent<Delivery>().currentProgress = car.Score;
                Debug.Log(playerCar.GetComponent<Delivery>().currentProgress);
                Debug.Log("Car moved to saved position.");
            }
        }

        
        if (data != null)
        {
            
            GameObject heartObj = GameObject.FindWithTag("Heart"); 
            if (heartObj != null)
            {
                heartObj.transform.position = data.HeartPosition;
            }

            
            GameObject packageObj = GameObject.FindWithTag("Package"); 
            if (packageObj != null)
            {
                packageObj.transform.position = data.PackagePosition;
            }
        }
    }

    public CarData RestoreCarData()
    {
        string path = Path.Combine(Application.persistentDataPath, "CarSave.json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            Debug.Log("Returned from: " + path);

            return JsonUtility.FromJson<CarData>(json);
        }
        else
        {
            Debug.LogError("Save file not found!");
            return null;
        }
        
    }
    public PlayerData RestorePLayerData()
    {
        string path = Path.Combine(Application.persistentDataPath, "PlayerSave.json");

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

    public void SaveGame(PlayerData data, CarData car)
    {
        
        string json = JsonUtility.ToJson(data, true);
        string json1 = JsonUtility.ToJson(car, true);
        
        string path = Path.Combine(Application.persistentDataPath, "PlayerSave.json");
        string path1 = Path.Combine(Application.persistentDataPath, "CarSave.json");
        
        File.WriteAllText(path, json);
        File.WriteAllText(path1, json1);
        
        Debug.Log("Saved to: " + path);
        Debug.Log("Saved to: " + path1);

    }
    
    public void DebugForButton(Button bt, UnityAction task){
        if (bt == null) {
            Debug.LogError("HEY! The saveButton variable is empty! Check the Inspector.");
        } else {
            Debug.Log("The saveButton is found: " + bt.name);
        }
        
        bt.onClick.AddListener(task);
    }

    public void SetDefaulData(){ 
        data = new PlayerData();
        car = new CarData();
        car.Health = 100;
        car.Score = 0;
        car.position = new Vector3(4.9f, 1.4f, -2f);
        car.rotation = new Quaternion (0,0,0,1);
        data.HeartPosition = new Vector3(3.26f, 1.4f, -2f);
        data.PackagePosition = new Vector3(16.22f, 4.1f, -2f);
        
    }

    public void SetRandomData()
    {
        data = new PlayerData();
        car = new CarData();
        car.Health = 30;
        car.Score = 5;
        car.position = new Vector3(4.46f, 15.37f, -2f);
        car.rotation = new Quaternion (0,0,90,0);
        data.HeartPosition = new Vector3(4.46f, 19.37f, -2f);
        data.PackagePosition = new Vector3(4.46f, 22.37f, -2f);
        
    }
}
