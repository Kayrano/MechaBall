using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class PlayerHealth : MonoBehaviour
    {
        #region Main Assignment
        PlayerScript playerS;
        #endregion

        #region
        

        #endregion
        private void Start()
        {
            playerS = GetComponent<PlayerScript>();
        }

        private void Update()
        {
            if(playerS.playerHealth <= 0)
            {
                playerS.isDead = true;
            }
        }

        public void TakeDamage()
        {

            playerS.playerHealth = playerS.playerHealth - 1;

        }


    }
}