using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint5 : MonoBehaviour
{
    public static event Events.CheckpointAchieved Checkpoint5Achieved;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) { return; }

        this.GetComponent<AudioSource>().PlayOneShot(this.GetComponent<AudioSource>().clip);

        Checkpoint5Achieved.Invoke(5);

        Invoke("NextLevel", 1f);
    }

    void NextLevel()
    {
        GameManager.Instance.UnLoadLevel(GameManager.currentLevel);

        GameManager.currentLevel = "Level6";

        GameManager.Instance.LoadLevel(GameManager.currentLevel);
    }
}
