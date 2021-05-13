using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectionMenu : MonoBehaviour
{

    public int levelsUnlocked = 0;

    public Button[] buttons;
    



    private void Start()
    {
        CheckLevels();
        
    }

    public void LoadSelectedLevel(string LevelToLoad)
    {
        int activeScenes = SceneManager.sceneCount;


        if(activeScenes == 1) 
        {
            GameManager.Instance.LoadLevel(LevelToLoad);
        }
        else if(activeScenes > 1)
        {
            GameManager.Instance.UnLoadLevel(GameManager.currentLevel);
            GameManager.Instance.LoadLevel(LevelToLoad);
        }

        

        

    }

    public void ResetLevels()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("levelsUnlocked", 1);

        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < levelsUnlocked; i++)
        {
            buttons[i].interactable = true;
        }

    }

    public void CheckLevels()
    {
        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < levelsUnlocked; i++)
        {
            buttons[i].interactable = true;
        }
    }

    


   
    




}
