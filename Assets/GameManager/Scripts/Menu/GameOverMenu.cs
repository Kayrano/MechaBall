using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private Button retryButton;
    [SerializeField] private Button menuButton;

    

    private void Start()
    {
        retryButton.onClick.AddListener(HandleRetryClicked);
        menuButton.onClick.AddListener(HandleMenuClicked);
        
    }

    private void HandleRetryClicked()
    {
        GameManager.Instance.Retry();
        this.gameObject.SetActive(false);
    }

    private void HandleMenuClicked()
    {
        GameManager.Instance.LoadMenu();
        this.gameObject.SetActive(false);
    }
}
