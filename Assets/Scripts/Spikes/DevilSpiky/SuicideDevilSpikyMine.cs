using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideDevilSpikyMine : MonoBehaviour
{
    [SerializeField] private List<EnemyTrigger> devilBases;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        foreach (var devilBase in this.GetComponentsInChildren<EnemyTrigger>())
        {
            devilBases.Add(devilBase);
        }

        foreach (var devilSpikyMine in devilBases)
        {
            Destroy(devilSpikyMine.enemyToActivate,4f);
        }

        

    }
}
