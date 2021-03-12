using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;



namespace Character
{
    public class PlayerInput : MonoBehaviour
    {
        #region Main Assignment
        PlayerScript playerS;
        #endregion

        #region Input Conditions
        internal bool isRightPressed;
        internal bool isLeftPressed;
        internal bool isJumpPressed;
        #endregion

        private void Start()
        {
            playerS = GetComponent<PlayerScript>();
            print("Input Initialized");
        }

        private void Update()
        {
            
            // Move Right Input
            if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                isRightPressed = true;
            }
            else
            {
                isRightPressed = false;
            }

            //Move Left Input
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                isLeftPressed = true;
            }
            else
            {
                isLeftPressed = false;
            }

            //Jump Input
            if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                isJumpPressed = true;
            }
            else
            {
                isJumpPressed = false;
            }
        }

    }
}