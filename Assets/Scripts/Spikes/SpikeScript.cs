
using UnityEngine;
using Character;


[RequireComponent(typeof(PlayerScript))]
public class SpikeScript : MonoBehaviour
{
    
    public PlayerScript PlayerS;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Spike Collided with player!!!" + collision.collider.name);
            PlayerS.playerH.TakeDamage();
            
        }
        
    }
    
        
}
