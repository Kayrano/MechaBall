using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace camera
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;

        public bool isJetpackOn = false;

        private void LateUpdate()
        {
            if (isJetpackOn)
            {

                if (target.position.x > transform.position.x / 2)
                    transform.position = new Vector3(target.position.x, target.position.y, 0);

            }
            else
            {
                if (target.position.x > transform.position.x / 2)
                    transform.position = new Vector3(target.position.x, transform.position.y, 0);
            }

        }

    }
}