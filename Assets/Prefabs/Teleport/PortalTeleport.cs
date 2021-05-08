using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    [SerializeField] Transform portalExit;
    [SerializeField] GameObject player;
    [SerializeField] int id;
    [SerializeField] Camera mainCamera;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) { return; }

        switch (id)
        {
            case 1:
                player.transform.position = portalExit.position;
                mainCamera.transform.position = new Vector3(0, -21);
                break;

            case 2:
                player.transform.position = portalExit.position;
                mainCamera.transform.position = new Vector3(0, -42);
                break;

            case 3:
                player.transform.position = portalExit.position;
                mainCamera.transform.position = new Vector3(0, -64);
                break;

            case 4:
                player.transform.position = portalExit.position;
                mainCamera.transform.position = new Vector3(0, -86);
                break;
        }

        player.transform.position = portalExit.position;




    }



}
