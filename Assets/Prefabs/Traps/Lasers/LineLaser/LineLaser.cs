using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

public class LineLaser : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 180;
    public Transform laserFirePoint;
    public LineRenderer m_lineRenderer;
    Transform m_transform;

    private float targetTime;
    private bool timerEnded = true;


    private void Start()
    {
        m_transform = GetComponent<Transform>();
    }

    private void Update()
    {
        ShootLaser();

        if (timerEnded) { return; }

        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f)
            timerEnded = true;
    }



    void ShootLaser()
    {
        if(Physics2D.Raycast(m_transform.position, transform.up))
        {
            RaycastHit2D _hit = Physics2D.Raycast(m_transform.position, transform.up);
            Draw2DRay(laserFirePoint.position, _hit.point);
            if (_hit.collider.CompareTag("Player"))
            {
                if (!timerEnded) { return; }

                PlayerHealth playerH = _hit.collider.GetComponent<PlayerHealth>();

                Debug.Log("Laser Collided with player!!!" + _hit.collider.name);
                playerH.TakeDamage();

                targetTime = 1.2f;
                timerEnded = false;
            }
        }
        else
        {
            Draw2DRay(laserFirePoint.position, laserFirePoint.transform.up * defDistanceRay);
        }

        
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
    }

}
