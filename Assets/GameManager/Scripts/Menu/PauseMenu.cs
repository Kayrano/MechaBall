using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button menuButton;
    
    

    private void Start()
    {
        resumeButton.onClick.AddListener(HandleResumeClicked);
        menuButton.onClick.AddListener(HandleMenuClicked);
        restartButton.onClick.AddListener(HandleRestartClicked);
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
