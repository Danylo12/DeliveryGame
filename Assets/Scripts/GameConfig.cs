using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Tilemaps;
using UnityEngine;


public static class GameConstants
{

    #region Tags & Layers
    public const string TAG_PLAYER = "Driver";
    public const string TAG_PACKAGE = "Package";
    public const string TAG_PERSON = "Person";
    public const string TAG_HEART = "Heart";
    public const string TAG_ROAD = "Road";
    #endregion

    #region Names
    public const string SCENE_MENU = "MenuScene";
    public const string SCENE_GAME = "GameScene";
    public const string SCENE_TUTORIAL = "tutorialScene";
    public const string SCENE_WIN = "WinScene";
    public const string SCENE_GAMEOVER = "GameOver";
    public const string SAVE_FILE = "Save.json";
    public const string SAVE_BUTTON = "Btn_Save";
    public const string RESTORE_BUTTON = "Btn_Restore";
    #endregion

    #region Gameplay Variables
    public static readonly Color32 pickedColor= new Color32(255, 255, 0, 255);
    public static readonly Color32 noPickedColor = new Color32(255, 255, 255, 255);
    public const int minProgress = 0;
    public const float steerSpeed = 200f;
    public const float moveSpeed = 7.5f;
    public const int maxHealth = 100;
    #endregion
    
    #region Path
    public static readonly string path = Path.Combine(Application.persistentDataPath, GameConstants.SAVE_FILE);
    #endregion

}
