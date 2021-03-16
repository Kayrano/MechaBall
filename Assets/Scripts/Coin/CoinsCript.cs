using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Character;


public class CoinsCript : MonoBehaviour
{
    public Text current_coin_text;
    public PlayerScript playerS;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Coin Collected by : " + collision.name);
            CollectCoin();

        }
    }

    private void Start()
    {
        current_coin_text.text = playerS.currentCoins.ToString();
    }

   


    public void CollectCoin()
    {
        playerS.currentCoins += 1 ;
        current_coin_text.text = playerS.currentCoins.ToString();
        Destroy(gameObject);
    }
}
