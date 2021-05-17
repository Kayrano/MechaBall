using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] internal GameObject enemyToActivate;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!collision.gameObject.CompareTag("Player")) { return; }

        enemyToActivate.SetActive(true);


        Collider2D boxCollider = this.GetComponent<Collider2D>();
        boxCollider.enabled = false;
    }
}
