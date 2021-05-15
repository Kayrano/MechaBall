using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineLaserTriggerSpawn : MonoBehaviour
{
    [SerializeField]List<GameObject> lineLasers;

    [SerializeField] GameObject lineLaserPrefab;

    [SerializeField] Transform upSpawnPoint;
    [SerializeField] Transform downSpawnPoint;



    private void Start()
    {
        SpawnUpLaser();
        SpawnDownLaser();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (!collision.gameObject.CompareTag("Player")) { return; }

        Debug.Log("Player entered the laser area!");

        


    }


    void SpawnUpLaser()
    {
        GameObject instantiatedLaserUp = Instantiate(lineLaserPrefab, upSpawnPoint.position, new Quaternion(0, 0, 180, 0));
        PathFollow pathLineUp = instantiatedLaserUp.GetComponent<PathFollow>();

        for (int i = 0; i < pathLineUp.patrolPoints.Count; i++)
        {
            pathLineUp.patrolPoints[i] = new Vector3(pathLineUp.patrolPoints[i].x, instantiatedLaserUp.transform.position.y, pathLineUp.patrolPoints[i].z);
                                       
        }

        lineLasers.Add(instantiatedLaserUp);

    }

    void SpawnDownLaser()
    {

        GameObject instantiatedLaserDown = Instantiate(lineLaserPrefab, downSpawnPoint.position, Quaternion.identity, downSpawnPoint);
        PathFollow pathLineDown = instantiatedLaserDown.GetComponent<PathFollow>();

        for (int i = 0; i < pathLineDown.patrolPoints.Count; i++)
        {
            pathLineDown.patrolPoints[i] = new Vector3(pathLineDown.patrolPoints[i].x, instantiatedLaserDown.transform.position.y, pathLineDown.patrolPoints[i].z);
        }

        lineLasers.Add(instantiatedLaserDown);
    }
}
