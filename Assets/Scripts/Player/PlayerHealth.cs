using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class PlayerHealth : MonoBehaviour
    {
        public float maximumHealth = 3;
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (maximumHealth <= 0)
                Die();

        }

        private void Die()
        {
            animator.SetBool("Die", true);
        }
        public void TakeDamage()
        {

        }
    }
}