using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    public int currentProgress;
    void Start()
    {
        SetMinProgress(GameConstants.minProgress);
        SetProgress(currentProgress);

    }

    public Slider slider;

    public void SetMinProgress(int progress)
    {
        slider.minValue = progress;
        slider.value = progress;
    }

    public void SetProgress(int progress)
    {
        slider.value = progress;
    }
    public void addProgress()
    {
        currentProgress++;
        SetProgress(currentProgress);
        if (currentProgress == 8)
        {
            GamePlay.WinScene();
        }
    }
    
}
