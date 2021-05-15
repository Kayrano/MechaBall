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

        playerS.JetpackOn();

        Destroy(gameObject);

    }


   



}
