using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint2 : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("Player")) { return; }


        GameManager.Instance.UnLoadLevel(GameData.currentLevel);

        GameData.currentLevel = "Level3";

        GameManager.Instance.LoadLevel(GameData.currentLevel);
    }

}
