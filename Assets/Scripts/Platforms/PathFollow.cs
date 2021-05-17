using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{
    [SerializeField] internal List<Vector3> patrolPoints = new List<Vector3>();
    [SerializeField] private float speed;
    [SerializeField] internal int nextPoint = 0;

    
    private void Update()
    {

        Patrol();

    }

    void Patrol()
    {
        if (transform.position == patrolPoints[nextPoint])
        {
            nextPoint++;
        }

        if (patrolPoints.Count <= nextPoint)
        {
            patrolPoints.Reverse();
            nextPoint = 1;
            Move();

        }

        Move();

    }

    void Move()
    {
        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[nextPoint], step);


    }

   

}
