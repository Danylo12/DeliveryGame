using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GamePlay
{
    
    public static void GameOver()
    {
        SceneManager.LoadScene(GameConstants.SCENE_GAMEOVER);
    }

    public static void WinScene()
    {
        SceneManager.LoadScene(GameConstants.SCENE_WIN);
    }
}
