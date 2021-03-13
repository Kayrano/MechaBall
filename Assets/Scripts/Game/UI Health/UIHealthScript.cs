using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using UnityEngine.UI;

public class UIHealthScript : MonoBehaviour
{
    #region Main Assignment
    public PlayerScript playerS;
    #endregion

    #region Images
    public Image healthimage1;
    public Image healthimage2;
    public Image healthimage3;
    #endregion

    private void Update()
    {
        HealthCounter();
        
    }


    void HealthCounter()
    {
        if(playerS.currentHealth == 2)
        {
            healthimage3.enabled = false;
        }
        if(playerS.currentHealth == 1)
        {
            healthimage3.enabled = false;
            healthimage2.enabled = false;
        }
        if(playerS.currentHealth == 0)
        {
            healthimage3.enabled = false;
            healthimage2.enabled = false;
            healthimage1.enabled = false;
        }
    }
}
