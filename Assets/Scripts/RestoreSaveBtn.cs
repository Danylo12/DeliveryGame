using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Localization;
using UnityEngine.U2D.Animation;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class RestoreSaveBtn : MonoBehaviour
{
    public static RestoreSaveBtn Instance;
    private PlayerData data;
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
        data = SaveManager.SetDefaulData();
        

    }


    public void ButtonRestorePressed()
    {
        data = SaveManager.RestorePLayerData();
        if (data != null)
        {
            RestoreGameScene();
        }
        else
        {
            data = SaveManager.SetDefaulData();
        }
    }

    public void ButtonSavePressed()
    {
        data = SaveManager.SetRandomData();
        SaveManager.SaveGame(data);
    }
    public void RestoreGameScene()
    {
        SceneManager.LoadScene(GameConstants.SCENE_GAME);
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene loaded! Searching for objects to restore...");

        GameObject btnSaveObj = GameObject.Find(GameConstants.SAVE_BUTTON); 
        if (btnSaveObj != null)
        {
            SaveButton = btnSaveObj.GetComponent<Button>();
            DebugForButton(SaveButton, ButtonSavePressed);
        }

        GameObject btnRestoreObj = GameObject.Find(GameConstants.RESTORE_BUTTON); 
        if (btnRestoreObj != null)
        {
            RestoreButton = btnRestoreObj.GetComponent<Button>();
            DebugForButton(RestoreButton, ButtonRestorePressed);
        }
        SaveManager.CreateObjectsFromData(data);
    }
    
    public void DebugForButton(Button bt, UnityAction task){
        if (bt == null) {
            Debug.LogError("HEY! The saveButton variable is empty! Check the Inspector.");
        } else {
            Debug.Log("The saveButton is found: " + bt.name);
        }
        
        bt.onClick.AddListener(task);
    }
    
}
