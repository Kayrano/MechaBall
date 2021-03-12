using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character {
    public class PlayerAnimation : MonoBehaviour
    {
        #region Main Assignment
        PlayerScript playerS;
        #endregion

        #region Animation Properties
        private Animator anim;
        public string CurrentState;
        public int currentState;
        #endregion

        #region Animations
        internal int idleAnim = Animator.StringToHash("Idle");
        internal int jumpAnim = Animator.StringToHash("Jump");
        internal int moveAnim = Animator.StringToHash("Move");
        internal int dieAnim = Animator.StringToHash("Die");
        #endregion


        private void Start()
        {
            playerS = GetComponent<PlayerScript>();
            anim = GetComponent<Animator>();

            anim.Play(idleAnim);
        }

        private void Update()
        {
            if (playerS.isDead)
            {
                ChangeState(dieAnim);
            }

            if (!playerS.isGrounded)
            {
                ChangeState(jumpAnim);
            }

            if (playerS.currentSpeed != 0 && playerS.isGrounded)
            {
                ChangeState(moveAnim);
            }
            else if (playerS.currentSpeed == 0 && playerS.isGrounded)
            {
                ChangeState(idleAnim);
            }



            
           

            
        }


        public void ChangeState(int newState)
        {
            if (currentState != dieAnim)
            {
                
                if (newState != currentState)
                {
                    anim.Play(newState);
                    currentState = newState;
                    
                }
            }
            else
            {
                print("DEAD!!");
            }

            CurrentState = currentState.ToString();

        }
    }
}