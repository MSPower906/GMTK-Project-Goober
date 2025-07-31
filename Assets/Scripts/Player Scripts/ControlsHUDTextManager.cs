using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlsHUDTextManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public HealthScript playerHealth;

    public TMP_Text Health;
    

    // Start is called before the first frame update
    void Start()
    {
        Health.text = "Health: " + (playerHealth.currentHealth + 1).ToString();

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Health.text = "Health: " + (playerHealth.currentHealth + 1).ToString();

      
    }
}
