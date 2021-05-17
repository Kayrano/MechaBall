using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

namespace camera
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        [SerializeField] private float startCameraYPosition;
        Rigidbody2D rb2dCamera;

        PlayerScript playerS;


        private void Start()
        {
            startCameraYPosition = transform.position.y;
            rb2dCamera = GetComponent<Rigidbody2D>();
            playerS = target.GetComponent<PlayerScript>();
        }
        private void LateUpdate()
        {
            

            if(playerS.GetJetpackStatus())
            {
                
                rb2dCamera.constraints = RigidbodyConstraints2D.None;

                transform.position = new Vector3(target.position.x, target.position.y, 0);

            }
            else if(!playerS.GetJetpackStatus())
            {
                
                if (target.position.x > transform.position.x / 2)
                    transform.position = new Vector3(target.position.x, startCameraYPosition, 0);

                rb2dCamera.constraints = RigidbodyConstraints2D.FreezePositionY;
            }

        }

        

    }
}