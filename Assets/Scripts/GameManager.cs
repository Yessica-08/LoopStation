using System;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{    
[SerializeField] Transform menuPanel;

[SerializeField] Transform settingsPanel;

    
    void Update()
    {
        ShowMenuPanel();
    }
    void ShowMenuPanel()
    {
      //Cursor.visible = true;
      //Cursor.lockState = CursorLockMode.None;
    }
  
}
