using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button quitButton;
    

    private void Start()
    {
        resumeButton.onClick.AddListener(HandleResumeClicked);
        menuButton.onClick.AddListener(HandleMenuClicked);
        quitButton.onClick.AddListener(HandleQuitClicked);
        restartButton.onClick.AddListener(HandleRestartClicked);
    }

    private void HandleQuitClicked()
    {
        GameManager.Instance.QuitGame();
    }

    private void HandleMenuClicked()
    {
        GameManager.Instance.LoadMenu();
    }

    private void HandleResumeClicked()
    {
        GameManager.Instance.TogglePause();
    }

    private void HandleRestartClicked()
    {
        GameManager.Instance.Retry();
    }
}
