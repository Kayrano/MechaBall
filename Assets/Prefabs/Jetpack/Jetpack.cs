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
        playerS.isJetpackOn = true;

        collision.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));

        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;




        Destroy(gameObject);
    }

}
