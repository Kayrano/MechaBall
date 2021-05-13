using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

public class Laser : MonoBehaviour
{

    private float targetTime;
    private bool timerEnded = true;

    private void Update()
    {
        if (timerEnded) { return; }

        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f)
            timerEnded = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) { return; }

        if (!timerEnded) { return; }

        PlayerScript playerS = collision.gameObject.GetComponent<PlayerScript>();

        Debug.Log("Laser triggered with player!!!");
        playerS.playerH.TakeDamage();

        targetTime = 0.5f;
        timerEnded = false;


    }



}
