using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

public class LineLaser : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 180;
    public Transform laserFirePoint;
    public LineRenderer m_lineRenderer;
    public ContactFilter2D filter;

    [SerializeField] Material hitMaterial;
    [SerializeField] Material defaultMaterial;

    Transform m_transform;

    RaycastHit2D[] raycastHit2Dresults;

    private float targetTime;
    private bool timerEnded = true;


    private void Start()
    {
        defaultMaterial = m_lineRenderer.material;
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
            RaycastHit2D _hit = Physics2D.Raycast(laserFirePoint.position, transform.up);
            Draw2DRay(laserFirePoint.position, _hit.point);

            if (_hit.collider.CompareTag("Player"))
            {
                m_lineRenderer.material = hitMaterial;

                if (!timerEnded) { return; }

                PlayerHealth playerH = _hit.collider.GetComponent<PlayerHealth>();

                Debug.Log("Laser Collided with player!!!" + _hit.collider.name);
                playerH.TakeDamage();

                targetTime = 1f;
                timerEnded = false;

            }
            else if (_hit.collider.CompareTag("DevilSpikyMine"))
            {
                m_lineRenderer.material = hitMaterial;
                Destroy(_hit.collider.gameObject,0.35f);
            }
            else if (!_hit.collider.CompareTag("Player") & !_hit.collider.CompareTag("DevilSpikyMine"))
            {
                m_lineRenderer.material = defaultMaterial;
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
