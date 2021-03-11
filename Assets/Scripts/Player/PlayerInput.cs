using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;



namespace Character
{
    public class PlayerInput : MonoBehaviour
    {
        PlayerMovementScript playerMovement;
        Animator animator;

        private PlayerCollider playerCollider;

        private Rigidbody2D rb2d;

        public bool jumpPressed = false;
        

        private float movepressed = 0f;
        public float MovePressed
        {
            get
            {
                return movepressed;
            }

            set
            {
                movepressed = value;
            }

            
        }
        

        

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovementScript>();
            rb2d = GetComponent<Rigidbody2D>();
            playerCollider = GetComponent<PlayerCollider>();
            animator = GetComponent<Animator>();
        }

       

        
        void Update()
        {
            movepressed = Input.GetAxisRaw("Horizontal");

            

            if (Input.GetButtonDown("Jump") && ((playerCollider.IsUp() || playerCollider.IsDown()) || (playerCollider.IsRight() || playerCollider.IsLeft())))
            {
                jumpPressed = true;
                
            }
        }


    }
}