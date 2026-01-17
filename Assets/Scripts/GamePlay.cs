using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GamePlay
{

    public static bool hasPackage;
    private static AudioManager audio;
    private static RenderScript driverRender;

    
    public static void GameOver()
    {
        SceneManager.LoadScene(GameConstants.SCENE_GAMEOVER);
    }

    public static void WinScene()
    {
        SceneManager.LoadScene(GameConstants.SCENE_WIN);
    }

    public static void SetActiveSmth(GameObject obj)
    {
        obj.SetActive(true);
        
    }

    public static void SmthHappened(GameObject obj, AudioClip sfx)
    {
        audio = GameObject.FindWithTag(GameConstants.TAG_PLAYER).GetComponent<AudioManager>();
        driverRender = GameObject.FindWithTag(GameConstants.TAG_PLAYER).GetComponent<RenderScript>();
        audio.AudioPlaySmth(sfx);
        Debug.Log(hasPackage);
        hasPackage = !hasPackage;
        Debug.Log(hasPackage);
        driverRender.ChangeColor();
        obj.transform.position = FindRandomPosition.RandomPosition();
        Debug.Log(obj);
        obj.SetActive(false);
        Debug.Log(obj);
    }

}
