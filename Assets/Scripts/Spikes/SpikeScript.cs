
using UnityEngine;
using Character;


public class SpikeScript : MonoBehaviour
{
    [SerializeField]
    PlayerScript PlayerHealth;

    private void Start()
    {
        
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Spike Collided with player!!!" + collision.collider.name);
            PlayerHealth.playerH.TakeDamage();
            
        }
        
    }
    
        
}
