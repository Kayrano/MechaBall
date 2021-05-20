using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
public class WaterEffect : MonoBehaviour
{
    [SerializeField] AudioClip dropClip;

    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();

    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) { return; }


        
        
        

        

    }



}
