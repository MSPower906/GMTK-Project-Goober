using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlsHUDTextManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public HealthScript playerHealth;

    public TMP_Text Health;
    public TMP_Text Charge1;
    public TMP_Text Charge2;

    // Start is called before the first frame update
    void Start()
    {
        Health.text = "Health: " + (playerHealth.currentHealth + 1).ToString();

        Charge1.text = "Charge1: " + playerMovement.Charge1.ToString();
        Charge2.text = "Charge2: " + playerMovement.Charge2.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Health.text = "Health: " + (playerHealth.currentHealth + 1).ToString();

        Charge1.text = "Charge1: " + playerMovement.Charge1.ToString();
        Charge2.text = "Charge2: " + playerMovement.Charge2.ToString();
    }
}
