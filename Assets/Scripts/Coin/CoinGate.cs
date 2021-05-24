using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

public class CoinGate : MonoBehaviour
{
    [SerializeField] PlayerScript playerS;

    [SerializeField] GameObject gate;

    private void Update()
    {
        if(playerS.currentCoins >= 2)
        {
            OpenGate();
        }
    }

    void OpenGate()
    {

        gate.GetComponent<PlatformEffector2D>().useOneWay = true;

    }
}
