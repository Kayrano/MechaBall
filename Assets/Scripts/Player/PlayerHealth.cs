using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Character
{
    public class PlayerHealth : MonoBehaviour
    {
        #region Main Assignment
        PlayerScript playerS;
        #endregion

        #region Healths
         
        

        #endregion
        private void Start()
        {
            playerS = GetComponent<PlayerScript>();
            
           
        }

        private void Update()
        {
            if(playerS.currentHealth <= 0)
            {
                playerS.isDead = true;
            }
        }

        public void TakeDamage()
        {

            playerS.currentHealth = playerS.currentHealth - 1;

        }


    }
}