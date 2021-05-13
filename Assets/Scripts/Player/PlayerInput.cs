using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;



namespace Character
{
    
    public class PlayerInput : MonoBehaviour
    {
        public enum DeviceType
        {
            PC,
            MOBILE
        }
        #region Main Assignment
        PlayerScript playerS;
        public Joystick joystick;

        public DeviceType _device;
        #endregion

        #region Input Conditions
        private bool isDead = false;

        internal bool isRightPressed;
        internal bool isLeftPressed;
        internal bool isJumpPressed;
        #endregion

        private void Start()
        {
            playerS = GetComponent<PlayerScript>();
            print("Input Initialized");

            if (Application.isMobilePlatform)
                _device = DeviceType.MOBILE;
            else
            {
                _device = DeviceType.PC;
            }

            PlayerScript.OnDie += HandleOnDie;

            
        }


        void HandleOnDie()
        {
            isDead = true;
        }


        private void Update()
        {
            if (isDead) { return; }

            switch (_device)
            {
                case DeviceType.PC:
                    pcInput();
                    break;
                case DeviceType.MOBILE:
                    mobileInput();
                    break;
                default:
                    break;
            }

        }

      

        public void pcInput()
        {
            // Move Right Input
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                isRightPressed = true;
            }
            else
            {
                isRightPressed = false;
            }

            //Move Left Input
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                isLeftPressed = true;
            }
            else
            {
                isLeftPressed = false;
            }

            //Jump Input
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                isJumpPressed = true;
            }
            else
            {
                isJumpPressed = false;
            }
        }
        public void mobileInput()
        {
          

            //Move right input
            if(joystick.Horizontal >= 0.1f)
            {
                isRightPressed = true;
            }
            else
            {
                isRightPressed = false;
            }
            //Move left input
            if(joystick.Horizontal <= -0.1f)
            {
                isLeftPressed = true;
            }
            else
            {
                isLeftPressed = false;
            }

            if(joystick.Vertical >= .5f)
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