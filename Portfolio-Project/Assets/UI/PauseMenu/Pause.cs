using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private PauseAction action;
    private bool paused;
    
    [SerializeField] MenuManagement inGameMenuManagement;

    void Awake()
    {
        action = new PauseAction();
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    void Start()
    {
        ResumeGame();
        action.Pause.PauseAction.performed += _ => DeterminePause();
    }

    private void DeterminePause()
    {
        if (paused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }
   public void PauseGame()
    {
        Time.timeScale = 0;
        paused = true;
        inGameMenuManagement.GoMain();
        Cursor.lockState = CursorLockMode.None;
    }

   public void ResumeGame()
   {
       Time.timeScale = 1;
       paused = false;
       inGameMenuManagement.GoPlay();
       Cursor.lockState = CursorLockMode.Locked;
    }
}
