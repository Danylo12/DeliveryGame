using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class CheckingForName : MonoBehaviour
{
    public GameObject blurPanel;
    public GameObject promptGroup;
    public TMP_InputField inputField;

    private bool inputReceived = false;
    [SerializeField] FileSavingFoBestScore save;

    void Start()
    {
        Time.timeScale = 0f;
        blurPanel.SetActive(true);
        promptGroup.SetActive(true);
        inputField.text = "";
        inputField.ActivateInputField();
    }

    void Update()
    {
        if (!inputReceived)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                if (!string.IsNullOrWhiteSpace(inputField.text))
                {
                    save.name = inputField.text;
                    inputReceived = true;
                    ResumeGame();
                }
            }
        }
    }

    void ResumeGame()
    {
        blurPanel.SetActive(false);
        promptGroup.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("User entered: " + save.name);
    }
}
