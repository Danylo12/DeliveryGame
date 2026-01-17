using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Exit : MonoBehaviour
{
    public void Quit() {
        #if UNITY_STANDALONE
            Application.Quit();
        #endif
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
