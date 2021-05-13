using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint2 : MonoBehaviour
{
    public static event Events.CheckpointAchieved Checkpoint2Achieved;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) { return; }

        Checkpoint2Achieved.Invoke(2);

        GameManager.Instance.UnLoadLevel(GameManager.currentLevel);

        GameManager.currentLevel = "Level3";

        GameManager.Instance.LoadLevel(GameManager.currentLevel);
    }

}
