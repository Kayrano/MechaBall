using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Character
{

    public class PlayerCollider : MonoBehaviour
    {

        [SerializeField]
        LayerMask platformLayerMask;
        
        CircleCollider2D circleCollider2D;
        Animator animator;
        


        private void Awake()
        {
            circleCollider2D = GetComponent<CircleCollider2D>();
            animator = GetComponent<Animator>();
        }


        
        


        private void Update()
        {
            if  (  (IsUp()||IsDown())  || (IsRight() || IsLeft()) )
            {
                animator.SetBool("IsGrounded", true);
                animator.SetBool("IsJump", false);
            }
            else 
            {
                
                animator.SetBool("IsGrounded", false);
            }

            
        }
     

        public bool IsUp()
        {
            float exceptHeight = 0.5f;
            Vector2 up = transform.TransformDirection(Vector2.up);
            Color rayColor;
            RaycastHit2D hit = Physics2D.Raycast(circleCollider2D.bounds.center, up, 1.61f, platformLayerMask);
            if (hit.collider)
            {
                rayColor = Color.green;
            }
            else
            {
                rayColor = Color.red;
            }
            Debug.DrawRay(circleCollider2D.bounds.center, up* (circleCollider2D.bounds.extents.y + exceptHeight), rayColor);
            return hit.collider != null;
        }
        public bool IsRight()
        {
            Color rayColor;
            float exceptHeight = 0.5f;
            Vector2 right = transform.TransformDirection(Vector2.right);
            RaycastHit2D hit = Physics2D.Raycast(circleCollider2D.bounds.center, right, 1.61f, platformLayerMask);
            if (hit.collider)
            {
                rayColor = Color.green;
            }
            else
            {
                rayColor = Color.red;
            }
            Debug.DrawRay(circleCollider2D.bounds.center, right * (circleCollider2D.bounds.extents.y + exceptHeight), rayColor);
            return hit.collider != null;
        }
        public bool IsLeft()
        {
            float exceptHeight = 0.5f;
            Vector2 left = transform.TransformDirection(Vector2.left);
            Color rayColor;
            RaycastHit2D hit = Physics2D.Raycast(circleCollider2D.bounds.center, left, 1.61f, platformLayerMask);
            if (hit.collider)
            {
                rayColor = Color.green;
            }
            else
            {
                rayColor = Color.red;
            }
            Debug.DrawRay(circleCollider2D.bounds.center, left * (circleCollider2D.bounds.extents.y + exceptHeight), rayColor);
            return hit.collider != null;
        }
        public bool IsDown()
        {
            float exceptHeight = 0.5f;
            Vector2 down = transform.TransformDirection(Vector2.down);
            Color rayColor;
            RaycastHit2D hit = Physics2D.Raycast(circleCollider2D.bounds.center, down, 1.61f, platformLayerMask);
            if (hit.collider)
            {
                rayColor = Color.green;
            }
            else
            {
                rayColor = Color.red;
            }
            Debug.DrawRay(circleCollider2D.bounds.center, down * (circleCollider2D.bounds.extents.y + exceptHeight), rayColor);
            return hit.collider != null;
        }




     



    }
}

