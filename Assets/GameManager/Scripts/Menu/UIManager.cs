using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : Singleton<UIManager>
{
    

    [SerializeField] private Camera _menuCamera;

    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private PauseMenu _pauseMenu;
    [SerializeField] private GameOverMenu _gameOverMenu;

   
    public Events.EventFadeComplete OnMainMenuFadeComplete;
    private void Start()
    {
        _mainMenu.OnMainMenuFadeComplete.AddListener(HandleMainMenuFadeComplete);
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
        
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnPauseButtonClicked();
        }
    }


    public void OnPauseButtonClicked() //Checks for pause clicked.
    {
        GameManager.Instance.TogglePause();
    }
    
    private void HandleMainMenuFadeComplete(bool fadeOut)
    {
        OnMainMenuFadeComplete.Invoke(fadeOut);
    }

    private void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        _pauseMenu.gameObject.SetActive(currentState == GameManager.GameState.PAUSED);

        _gameOverMenu.gameObject.SetActive(currentState == GameManager.GameState.DEAD);



    }

    public void SetMenuCameraActive(bool active)
    {
        _menuCamera.gameObject.SetActive(active);
    } 
    

    
}
