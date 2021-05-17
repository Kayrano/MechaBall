using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    [SerializeField] Transform portalExit;
    [SerializeField] GameObject player;
    [SerializeField] int id;
    

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) { return; }


        player.transform.position = portalExit.position;




    }



}
