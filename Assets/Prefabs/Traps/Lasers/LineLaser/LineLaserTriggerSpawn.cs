using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineLaserTriggerSpawn : MonoBehaviour
{
    [SerializeField]List<GameObject> lineLasers;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) { return; }

        Debug.Log("Player entered the laser area!");

        foreach (var laser in lineLasers)
        {
            laser.SetActive(true);
        }

        

    }


   

    
}
