using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint1 : MonoBehaviour
{

    public static event Events.CheckpointAchieved Checkpoint1Achieved;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("Player")) { return; }

        Checkpoint1Achieved.Invoke(1);

        GameManager.Instance.UnLoadLevel(GameManager.currentLevel);

        GameManager.currentLevel = "Level2";

        GameManager.Instance.LoadLevel(GameManager.currentLevel);

    }

}
