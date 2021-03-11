using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Character
{
    public class PlayerScript : MonoBehaviour
    {
        PlayerCollider playerCollider;
        
        PlayerMovementScript playerMovementScript;

        void Awake()
        {
            playerCollider = GetComponent<PlayerCollider>();
            playerMovementScript = GetComponent<PlayerMovementScript>();
            
        }
        
            
        

        // Update is called once per frame
        void Update()
        {
            

        }

       
    }
}