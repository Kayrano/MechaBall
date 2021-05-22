using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

public class PortalTeleportExit : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    [SerializeField] GameObject player;

    bool hasExit = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasExit) { return; }

        hasExit = true;
        

        audioSource.Play();

        Invoke("BeVisible", 1f);

        PlayerMovementScript playerM = player.GetComponent<PlayerMovementScript>();

        playerM.enabled = true;


    }

    private void BeVisible()
    {

        player.transform.position = this.transform.position;


    }


}
