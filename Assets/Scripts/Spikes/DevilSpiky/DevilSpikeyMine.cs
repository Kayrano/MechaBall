using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;

public class DevilSpikeyMine : MonoBehaviour
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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            if (!timerEnded) { return; }

            PlayerHealth playerH = collision.gameObject.GetComponent<PlayerHealth>();

            Debug.Log("Spike Collided with player!!!" + collision.collider.name);
            playerH.TakeDamage();

            targetTime = 1f;
            timerEnded = false;

        }

        else if (collision.gameObject.CompareTag("Laser"))
        {

            // Do die and particle blowing up effects

        }
        



    }

}
