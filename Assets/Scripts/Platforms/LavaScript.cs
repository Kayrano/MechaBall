using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!collision.gameObject.CompareTag("Player")) { return; }

        PlayerHealth playerH = collision.gameObject.GetComponent<PlayerHealth>();

        playerH.TakeDamage();
        playerH.TakeDamage();
        playerH.TakeDamage();

    }
}
