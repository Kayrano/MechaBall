using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup_Standard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) { return; }

        Rigidbody2D rb2d = collision.gameObject.GetComponent<Rigidbody2D>();

        Renderer[] renderer = collision.gameObject.GetComponentsInChildren<Renderer>();

        renderer[2].material.color = Color.white;

        rb2d.mass = 1;

        Debug.Log("STANDARD POWERUP USED!");

        Destroy(this.gameObject);

    }
}
