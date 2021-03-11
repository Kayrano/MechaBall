using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Character
{
    public class PlayerMovementScript : MonoBehaviour
    {
        Rigidbody2D rb2d;
        PlayerInput playerInput;
        PlayerCollider playerCollider;
        Animator animator;
        
        

        #region Properties



        [SerializeField][Range(0,20f)]
        private float jumpForce = 30f;
        public float JumpForce
        {
            get => jumpForce;


            set => jumpForce = value;
            
        }

        internal float horizontalMove;

        [SerializeField]
        private float moveSpeed = 50f;
        public float MoveSpeed
        {
            get => moveSpeed;

            set => moveSpeed = value;
        }

        
        private Vector3 velocity = Vector3.zero;
        #endregion

        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
            playerInput = GetComponent<PlayerInput>();
            playerCollider = GetComponent<PlayerCollider>();
            animator = GetComponent<Animator>();
            
        }
        

        private void FixedUpdate()
        {



            if (Mathf.Abs(playerInput.MovePressed) > 0.01f)
            {
                Move();
            }
            

            if (playerInput.jumpPressed )
            {
                Jump();
                playerInput.jumpPressed = false;
                
            }


                
        }

        public void Jump()
        {
            if (playerCollider.IsUp())
            {
                animator.SetBool("IsJump", true);
                rb2d.velocity = Vector2.down * jumpForce;
            }
            else if (playerCollider.IsDown())
            {
                animator.SetBool("IsJump", true);
                rb2d.velocity = Vector2.up * jumpForce*1.25f;
            }
            else if (playerCollider.IsLeft())
            {
                animator.SetBool("IsJump", true);
                rb2d.velocity = Vector2.right * jumpForce/2;
            }
            else if (playerCollider.IsRight())
            {
                animator.SetBool("IsJump", true);
                rb2d.velocity = Vector2.left * jumpForce/2;
            }



        }

        public void Move()
        {
            horizontalMove = playerInput.MovePressed * moveSpeed * Time.fixedDeltaTime;
            Vector3 targetVelocity = new Vector2(horizontalMove * 10f, rb2d.velocity.y);

            rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, targetVelocity, ref velocity, .05f);

           
            
        }

        
    }
}
