using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

public class JetpackOff : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) { return; }

        PlayerScript playerS =  collision.GetComponent<PlayerScript>();

        playerS.JetpackOff();
        

    }

}
