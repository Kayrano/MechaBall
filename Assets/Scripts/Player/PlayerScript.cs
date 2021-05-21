using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using camera;


namespace Character
{
    public class PlayerScript : MonoBehaviour
    {

        public static event Events.DieAction OnDie;

        #region Child Assignments
        internal PlayerHealth playerH;
        internal PlayerInput playerI;
        internal PlayerMovementScript playerM;
        internal PlayerCollider playerC;
        #endregion

        #region Components
        internal Rigidbody2D rb2d;
        internal Collider2D playerCollider;

        [SerializeField]internal Camera mainCamera;

        #endregion

        #region Properties
        private int maximumHealth = 3;
        public int currentHealth;

        internal bool isDead = false;
        bool hasEnded = false;
        
       


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

        #region Jetpack
        [SerializeField] GameObject Jetpack;

        private bool isJetpackOn = false;

        

        public bool GetJetpackStatus()
        {
            return isJetpackOn;
        }

        public void JetpackOn()
        {
            Jetpack.gameObject.SetActive(true);
            isJetpackOn = true;

            rb2d.rotation = 360;

            rb2d.angularVelocity = 0;

            rb2d.drag = 0.7f;

            if (rb2d.rotation == 360)
                rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;

        }

        public void JetpackOff()
        {
            Jetpack.gameObject.SetActive(false);
            isJetpackOn = false;

            rb2d.constraints = RigidbodyConstraints2D.None;

            rb2d.drag = 0;

        }

        
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

        private void Update()
        {
            if (isDead)
            {

                OnDied();


                if (!hasEnded)
                {
                    OnDie.Invoke();
                    hasEnded = true;
                }
                   
                    

            }
        }


        void OnDied()
        {
            rb2d.velocity = new Vector2(0, 0);
            moveSpeed = 0;

            Collider2D[] colliders = this.gameObject.GetComponents<Collider2D>();

            foreach (var collider in colliders) 
            {
                collider.enabled = false;
            }

        }




    }
}