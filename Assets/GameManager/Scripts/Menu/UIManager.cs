using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : Singleton<UIManager>
{
    

    [SerializeField] private Camera _menuCamera;

    [SerializeField] private LevelSelectionMenu levelSelectionMenu;
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private PauseMenu _pauseMenu;
    [SerializeField] private GameOverMenu _gameOverMenu;

   
    public Events.EventFadeComplete OnMainMenuFadeComplete;
    private void Start()
    {
        _mainMenu.OnMainMenuFadeComplete.AddListener(HandleMainMenuFadeComplete);
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);

        Checkpoint1.Checkpoint1Achieved += HandleCheckpoint1Achieved;
        Checkpoint2.Checkpoint2Achieved += HandleCheckpoint2Achieved;
        Checkpoint3.Checkpoint3Achieved += HandleCheckpoint3Achieved;


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


    #region Checkpoint Methods

    void HandleCheckpoint1Achieved(int currentLevel)
    {
        Debug.Log("[UIMANAGER]Checkpoint Event activated");


        if (currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", currentLevel + 1);
        }

        Debug.Log("Level" + PlayerPrefs.GetInt("levelsUnlocked") + "Unlocked");

        levelSelectionMenu.CheckLevels();

        PlayerPrefs.Save();

    }

    void HandleCheckpoint2Achieved(int currentLevel)
    {
        Debug.Log("[UIMANAGER]Checkpoint Event activated");


        if (currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", currentLevel + 1);
        }

        Debug.Log("Level" + PlayerPrefs.GetInt("levelsUnlocked") + "Unlocked");

        levelSelectionMenu.CheckLevels();

        PlayerPrefs.Save();

    }

    void HandleCheckpoint3Achieved(int currentLevel)
    {
        Debug.Log("[UIMANAGER]Checkpoint Event activated");


        if (currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", currentLevel + 1);
        }

        Debug.Log("Level" + PlayerPrefs.GetInt("levelsUnlocked") + "Unlocked");

        levelSelectionMenu.CheckLevels();

        PlayerPrefs.Save();
    }

    #endregion






}
