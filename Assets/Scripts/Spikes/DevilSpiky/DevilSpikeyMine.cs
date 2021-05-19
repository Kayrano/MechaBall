using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;
using Pathfinding;

public class DevilSpikeyMine : MonoBehaviour
{

    private float targetTime;
    private bool timerEnded = true;
    [SerializeField] internal GameObject explosionPrefab;
    [SerializeField] internal AudioClip explosionSound;
    


    private void Update()
    {
        if (timerEnded) { return; }

        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f)
            timerEnded = true;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            if (!timerEnded) { return; }

            PlayerHealth playerH = collision.gameObject.GetComponent<PlayerHealth>();

            Debug.Log("Spike Collided with player!!!" + collision.collider.name);
            playerH.TakeDamage();

            targetTime = 1f;
            timerEnded = false;

        }

    }


    public void Explode()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;

        gameObject.GetComponent<SpriteRenderer>().enabled = false;

        Instantiate(explosionPrefab, transform);

        this.gameObject.GetComponent<AudioSource>().PlayOneShot(explosionSound);

        this.gameObject.GetComponent<AIPath>().canMove = false;

        Destroy(this.gameObject, 2f);
    }


}
