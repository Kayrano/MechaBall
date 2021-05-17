using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint4 : MonoBehaviour
{
    public static event Events.CheckpointAchieved Checkpoint4Achieved;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) { return; }

        Checkpoint4Achieved.Invoke(4);

        GameManager.Instance.UnLoadLevel(GameManager.currentLevel);

        GameManager.currentLevel = "Level5";

        GameManager.Instance.LoadLevel(GameManager.currentLevel);
    }
}
