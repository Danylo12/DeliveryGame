using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public SaveSystem sav;
    public void LoadScene()
    {
        sav = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SaveSystem>();
        sav.SetDefaulData();
        SceneManager.LoadScene("SampleScene");
    }
    
}