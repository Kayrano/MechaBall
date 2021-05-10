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

        #endregion

        private void Start()
        {
            playerS = GetComponent<PlayerScript>();
            print("Player Movement Initialized");
        }
        private void FixedUpdate()
        {
            playerS.currentSpeed = Mathf.Abs(playerS.rb2d.velocity.x);

            //Do Jetpack Movement
            if(playerS.GetJetpackStatus() == true)
            {
                //Fly Right
                if (playerS.playerI.isRightPressed)
                {
                    FlyRight();

                }
                //Fly Left
                if (playerS.playerI.isLeftPressed)
                {
                    FlyLeft();

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
            playerS.rb2d.AddRelativeForce(Vector3.up * jetpackThrust);
        }
        internal void FlyRight()
        {
            Vector3 velocity = Vector3.zero;
            Vector3 targetVelocity = new Vector2(playerS.moveSpeed * Time.fixedDeltaTime, playerS.rb2d.velocity.y);
            playerS.rb2d.velocity = Vector3.SmoothDamp(playerS.rb2d.velocity, targetVelocity, ref velocity, .05f);
        }

        internal void FlyLeft()
        {
            Vector3 velocity = Vector3.zero;
            Vector3 targetVelocity = new Vector2(-playerS.moveSpeed * Time.fixedDeltaTime, playerS.rb2d.velocity.y);
            playerS.rb2d.velocity = Vector3.SmoothDamp(playerS.rb2d.velocity, targetVelocity, ref velocity, .05f);
        }


        #endregion









    }
}
