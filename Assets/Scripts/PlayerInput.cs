using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private Rigidbody2D rb2d;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    
}
