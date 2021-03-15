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
    
    

    private void Update()
    {
        health = playerS.currentHealth;


        if (health <= 0) {

            GameOver();
        }
            
        
    }


    public void GameOver()
    {
        Debug.Log("GAMEOVER WORKING");
        ControllerUI.SetActive(false);
        GameplayUI.SetActive(false);
        GameOverMenu.SetActive(true);
        Time.timeScale = 0f;
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
