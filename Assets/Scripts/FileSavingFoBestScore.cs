using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileSavingFoBestScore : MonoBehaviour
{
    string path;
    public string name;
    public int score;
    
    private void Awake()
    {
        path = Application.persistentDataPath + "/bestScores.txt";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "");
            Debug.Log("File created at: " + path);
        }
    }
    public void SavesScore()
    {
        
        File.AppendAllText(path, $"{name} - {score}\n");
        
    }

    public void ReadFile()
    {
        string content = File.ReadAllText(path);
        Debug.Log("File contents: " + content);

        
    }
}
