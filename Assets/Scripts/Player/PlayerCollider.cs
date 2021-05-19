using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Character
{

    public class PlayerCollider : MonoBehaviour
    {
        #region Main Assignment
        PlayerScript playerS;
        #endregion

        
        private void Start()
        {
            playerS = GetComponent<PlayerScript>();
        }

        private void FixedUpdate()
        {
            playerS.isGrounded = Physics2D.OverlapCircle(playerS.groundCheckPoint.position, playerS.checkRadius, playerS.groundLayer);
            
        }


    }
}

