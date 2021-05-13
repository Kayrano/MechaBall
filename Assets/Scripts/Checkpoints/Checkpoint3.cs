using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint3 : MonoBehaviour
{
    public static event Events.CheckpointAchieved Checkpoint3Achieved;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) { return; }

        Checkpoint3Achieved.Invoke(3);

        GameManager.Instance.UnLoadLevel(GameManager.currentLevel);

        GameManager.currentLevel = "Level4";

        GameManager.Instance.LoadLevel(GameManager.currentLevel);
    }

}
