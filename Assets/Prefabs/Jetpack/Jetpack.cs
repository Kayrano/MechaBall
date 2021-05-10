using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

public class Jetpack : MonoBehaviour
{
    PlayerScript playerS = null; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) { return; }

        playerS = collision.GetComponent<PlayerScript>();

        Rigidbody2D rb2d = collision.GetComponent<Rigidbody2D>();

        

        playerS.JetpackOn();
        

        
        //rb2d.velocity = new Vector2(0,0);

        rb2d.rotation = 0;

        rb2d.angularVelocity = 0;
        

        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;




        Destroy(gameObject);


        
    }

}
