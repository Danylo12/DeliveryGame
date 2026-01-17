using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DeleteFile : MonoBehaviour
{

    public void Delete()
    {
        string playerPath = Path.Combine(Application.persistentDataPath, GameConstants.SAVE_FILE);
        if (File.Exists(playerPath))
        {
            File.Delete(playerPath);
            Debug.Log("Deleted: " + playerPath);
        }

        GamePlay.GameOver();

    }
}
