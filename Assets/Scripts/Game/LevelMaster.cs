using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMaster : MonoBehaviour
{
    public static LevelMaster instance = null; //declaring and initializing a public static LevelManager to null. This will be used shortly.

    public static int currentLevel;



    private void Awake()
    {
        if (instance == null) // determine if our instance null
            instance = this;

        else if (instance != this) //determine if our intance is already assigned to something else
            Destroy(gameObject);

    }

    
}
