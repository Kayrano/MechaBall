using UnityEngine;
using Character;
using System.Collections;


public class SpikeScript : MonoBehaviour
{
    
    public PlayerScript PlayerS;
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
        if(!collision.gameObject.CompareTag("Player")) { return; }

        if (!timerEnded) { return; }

        Debug.Log("Spike Collided with player!!!" + collision.collider.name);
        PlayerS.playerH.TakeDamage();

        targetTime = 1.2f;
        timerEnded = false;
        

        
    }
    
        
}
