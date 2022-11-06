using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUICounter : MonoBehaviour
{
     public Text healthText;

    
    JSONSavingScript data;

    private void FixedUpdate()
    {
        HealthCounter();
        if(data == null)
        {
            Debug.LogWarning("Player data are missing");
        }
    }
    private void Start()
    {
    
        data = GetComponent<JSONSavingScript>();
        

    }
    public void HealthCounter()
    {
        if(data == null)
        {
            gameObject.GetComponent<PlayerUICounter>().enabled = false;
        }
        else
        { 
            healthText.text = data.myplayer.health.ToString();
        }
        
    }

}
