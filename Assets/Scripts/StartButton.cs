using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public PlayerData data;
    public void LoadScene()
    {
        data = SaveManager.SetDefaulData();
        SceneManager.LoadScene("GameScene");
    }
    
}