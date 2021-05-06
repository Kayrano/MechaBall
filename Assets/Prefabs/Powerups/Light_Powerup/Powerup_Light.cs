using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup_Light : MonoBehaviour
{
    [SerializeField] float gravity = 0.2f;
    [SerializeField] float mass = 1f;
    [SerializeField] Color newColor = Color.magenta;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) { return; }

        Rigidbody2D rb2d = collision.gameObject.GetComponent<Rigidbody2D>();

        Renderer[] renderer = collision.gameObject.GetComponentsInChildren<Renderer>();

        renderer[2].material.color = newColor;

        rb2d.mass = mass;

        rb2d.gravityScale = gravity;

        Debug.Log("LIGHT POWERUP USED!");

        Destroy(this.gameObject);



    }




}
