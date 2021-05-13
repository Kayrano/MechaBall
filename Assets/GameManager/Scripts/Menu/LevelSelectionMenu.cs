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
        
        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 0);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < levelsUnlocked; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void LoadSelectedLevel(string LevelToLoad)
    {
        GameManager.Instance.LoadLevel(LevelToLoad);
    }

    

    

    


   
    




}
