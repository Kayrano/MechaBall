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
        
        #endregion

        private void Start()
        {
            playerS = GetComponent<PlayerScript>();
            print("Player Movement Initialized");
        }
        private void FixedUpdate()
        {
            playerS.currentSpeed = Mathf.Abs(playerS.rb2d.velocity.x);

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





        #region Movement Methods
        internal void MoveRight()
        {
            Vector3 velocity = Vector3.zero;
            Vector3 targetVelocity = new Vector2(playerS.moveSpeed * Time.fixedDeltaTime, playerS.rb2d.velocity.y);
            playerS.rb2d.velocity = Vector3.SmoothDamp(playerS.rb2d.velocity,targetVelocity,ref velocity, .05f);
            
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


        






    }
}
