using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Character
{
    public class PlayerMovementScript : MonoBehaviour
    {
        #region Main Assignment
        PlayerScript playerS;
        #endregion

        #region Properties

        [SerializeField] private float jetpackThrust = 10f;
        
        

        Rigidbody2D rb2d;

        #endregion

        #region Jetpack Properties

        [SerializeField]JetpackPin jetpackPin;

        private bool isFacingRight = true;
        
        

        #endregion

        private void Start()
        {
            playerS = GetComponent<PlayerScript>();
            print("Player Movement Initialized");
            rb2d = playerS.rb2d;
            
            
        }
        private void FixedUpdate()
        {
            
            //Do Jetpack Movement
            if(playerS.GetJetpackStatus() == true)
            {
                //Fly Right
                if (playerS.playerI.isRightPressed)
                {
                    FlyRight();



                    if (!isFacingRight)
                    {
                        Flip();
                    }
                    

                }
                //Fly Left
                if (playerS.playerI.isLeftPressed)
                {

                    FlyLeft();

                    if (isFacingRight)
                    {
                        Flip();
                    }
                    
                    

                }
                //Fly Up
                if (playerS.playerI.isJumpPressed)
                {
                    Thrust();

                    playerS.playerI.isJumpPressed = false;
                }

                
            }

            //Do Basic Movement
            if(playerS.GetJetpackStatus() == false)
            {

                //Move Right
                if (playerS.playerI.isRightPressed)
                {
                    MoveRight();
                    

                }
                //Move Left
                if (playerS.playerI.isLeftPressed)
                {
                    MoveLeft();
                    

                }
                //Jump
                if (playerS.playerI.isJumpPressed && playerS.isGrounded)
                {
                    Jump();

                    playerS.playerI.isJumpPressed = false;
                }

            }



            playerS.currentSpeed = Mathf.Abs(playerS.rb2d.velocity.x);

            
        }





        #region Basic Movement Methods
        internal void MoveRight()
        {
            Vector3 velocity = Vector3.zero;
            Vector3 targetVelocity = new Vector2(playerS.moveSpeed * Time.fixedDeltaTime, playerS.rb2d.velocity.y);
            playerS.rb2d.velocity = Vector3.SmoothDamp(playerS.rb2d.velocity, targetVelocity, ref velocity, .05f);
            
        }
        internal void MoveLeft()
        {
            Vector3 velocity = Vector3.zero;
            Vector3 targetVelocity = new Vector2(-playerS.moveSpeed * Time.fixedDeltaTime, playerS.rb2d.velocity.y);
            playerS.rb2d.velocity = Vector3.SmoothDamp(playerS.rb2d.velocity, targetVelocity, ref velocity, .05f);

        }
        internal void Jump()
        {
            playerS.rb2d.velocity = Vector3.up * playerS.jumpSpeed;
           
        }


        #endregion


        #region Jetpack Movement Methods


        internal void Thrust()
        {
            playerS.rb2d.AddForce(Vector3.up * jetpackThrust);
            jetpackPin.FlyHorizontalEffect();
        }
        internal void FlyRight()
        {
            Vector3 velocity = Vector3.zero;
            Vector3 targetVelocity = new Vector2(playerS.moveSpeed * Time.fixedDeltaTime, playerS.rb2d.velocity.y);
            playerS.rb2d.velocity = Vector3.SmoothDamp(playerS.rb2d.velocity, targetVelocity, ref velocity, .05f);
            jetpackPin.FlyVerticalEffect();
            
        }
        internal void FlyLeft()
        {
            Vector3 velocity = Vector3.zero;
            Vector3 targetVelocity = new Vector2(-playerS.moveSpeed * Time.fixedDeltaTime, playerS.rb2d.velocity.y);
            playerS.rb2d.velocity = Vector3.SmoothDamp(playerS.rb2d.velocity, targetVelocity, ref velocity, .05f);
            jetpackPin.FlyVerticalEffect();
        }

        private void Flip()
        {
            isFacingRight = !isFacingRight;

            transform.Rotate(0, 180, 0);
        }

        #endregion









    }
}
