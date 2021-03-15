using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Character
{
    public class PlayerScript : MonoBehaviour
    {
        #region Child Assignments
        internal PlayerHealth playerH;
        internal PlayerInput playerI;
        internal PlayerMovementScript playerM;
        internal PlayerCollider playerC;
        #endregion

        #region Components
        internal Rigidbody2D rb2d;
        internal Collider2D playerCollider;


        #endregion

        #region Properties
        private int maximumHealth = 3;
        public int currentHealth;
        
        internal bool isDead = false;

        public float moveSpeed = 25f;
        public float jumpSpeed = 45f;
        public float currentSpeed;

        public int currentCoins = 0;
        #endregion

        #region Ground Check Properties
        internal bool isGrounded;
        public Transform groundCheckPoint;
        public float checkRadius;
        public LayerMask groundLayer;
        #endregion

        private void Awake()
        {
            
            playerH = GetComponent<PlayerHealth>();
            playerI = GetComponent<PlayerInput>();
            playerM = GetComponent<PlayerMovementScript>();
            playerC = GetComponent<PlayerCollider>();

            playerCollider = GetComponent<Collider2D>();
            rb2d = GetComponent<Rigidbody2D>();
            
            
            
            print("Player Script Initialized");
        }

        private void Start()
        {
            currentHealth = maximumHealth;
        }






    }
}