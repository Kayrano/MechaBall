using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineLaser : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 180;
    public Transform laserFirePoint;
    public LineRenderer m_lineRenderer;
    Transform m_transform;


    private void Start()
    {
        m_transform = GetComponent<Transform>();
    }

    private void Update()
    {
        ShootLaser();
    }



    void ShootLaser()
    {
        if(Physics2D.Raycast(m_transform.position, transform.up))
        {
            RaycastHit2D _hit = Physics2D.Raycast(m_transform.position, transform.up);
            Draw2DRay(laserFirePoint.position, _hit.point);
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
