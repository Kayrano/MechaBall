using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public PlayerScript playerS;
    public GameObject GameOverMenu;
    public GameObject GameplayUI;
    public GameObject ControllerUI;
    int health;
    bool isOver;
    
    

    private void Update()
    {
        health = playerS.currentHealth;


        if (health <= 0 && !isOver) {

            GameOver();
        }
            
        
    }


    public void GameOver()
    {
        Time.timeScale = 0.1f;
        Debug.Log("GAMEOVER WORKING");
        ControllerUI.SetActive(false);
        GameplayUI.SetActive(false);
        GameOverMenu.SetActive(true);
        isOver = true;
        
    }
    
    public void Retry()
    {
        ControllerUI.SetActive(true);
        GameplayUI.SetActive(true);
        GameOverMenu.SetActive(false);
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuScene");
        

    }

    
}
