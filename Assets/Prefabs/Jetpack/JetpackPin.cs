using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

public class JetpackPin : MonoBehaviour
{

    [Header("Audio Sources")]
    [SerializeField]AudioSource audioSource1;
    [SerializeField]AudioSource audioSource2;

    [Header("Particle Systems")]
    [SerializeField] ParticleSystem PressurisedSteam;
    [SerializeField] ParticleSystem RocketFlame;

    

    public void FlyVerticalEffect()
    {
        PressurisedSteam.Play();
        if (!audioSource1.isPlaying)
        {
            audioSource1.Play();
        }
        
    }

    public void FlyHorizontalEffect()
    {
        RocketFlame.Play(true);
        if (!audioSource2.isPlaying)
        {
            audioSource2.Play();
        }
        
    }

   

}
