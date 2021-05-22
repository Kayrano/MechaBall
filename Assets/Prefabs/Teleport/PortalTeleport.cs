using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

public class PortalTeleport : MonoBehaviour
{
    [SerializeField] Transform portalExit;
    [SerializeField] GameObject player;
    bool hasEntered = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!collision.gameObject.CompareTag("Player")) { return; }

        if (hasEntered) { return; }

        hasEntered = true;

        PlayerMovementScript playerM = player.GetComponent<PlayerMovementScript>();

        playerM.enabled = false;

        player.transform.position = new Vector3(portalExit.transform.position.x, portalExit.transform.position.y, -11);

        Rigidbody2D rb2d = player.GetComponent<Rigidbody2D>();


        rb2d.velocity = new Vector2(0, 0);
        rb2d.angularVelocity = 0;


    }



}
