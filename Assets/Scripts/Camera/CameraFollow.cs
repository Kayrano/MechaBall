using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace camera
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;

        public float smoothspeed = 0.5f;

        private void Start()
        {
          
            


        }
        private void LateUpdate()
        {
            if(target.position.x > transform.position.x /2)
                transform.position = new Vector3(target.position.x , 0,0) * smoothspeed;

           
        }

    }
}