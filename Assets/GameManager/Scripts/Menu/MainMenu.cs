using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Track the animation 
    // Track the animation clips 
    // Function that can receive animation events
    // Functions to play fade in/out

    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    [SerializeField] private Animation _mainMenuAnimator;
    [SerializeField] private AnimationClip _fadeOutAnim;
    [SerializeField] private AnimationClip _fadeInAnim;

    public Events.EventFadeComplete OnMainMenuFadeComplete;

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);

        playButton.onClick.AddListener(HandlePlayButtonClicked);

        quitButton.onClick.AddListener(HandleQuitButtonClicked);

    }

    private void HandlePlayButtonClicked()
    {
        GameManager.Instance.StartGame();
    }

    private void HandleQuitButtonClicked()
    {
        GameManager.Instance.QuitGame();
    }

    private void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if(previousState == GameManager.GameState.PREGAME && currentState == GameManager.GameState.RUNNING)
        {
            FadeOut();
        }
        if(previousState == GameManager.GameState.PAUSED && currentState == GameManager.GameState.PREGAME)
        {
            
            FadeIn();
        }
        if (previousState == GameManager.GameState.DEAD && currentState == GameManager.GameState.PREGAME)
        {

            FadeIn();
        }

    }

    public void OnFadeOutComplete()
    {
        OnMainMenuFadeComplete.Invoke(true);
    }

    public void OnFadeInComplete()
    {
        OnMainMenuFadeComplete.Invoke(false);
        UIManager.Instance.SetMenuCameraActive(true);
        
    }


    public void FadeOut()
    {
        Debug.Log("Fade Out");

        UIManager.Instance.SetMenuCameraActive(false);
        

        _mainMenuAnimator.Stop();
        _mainMenuAnimator.clip = _fadeOutAnim;
        _mainMenuAnimator.Play();
    }

    public void FadeIn()
    {
        Debug.Log("Fade In");
        _mainMenuAnimator.Stop();
        _mainMenuAnimator.clip = _fadeInAnim;
        _mainMenuAnimator.Play();
    }

   

}
