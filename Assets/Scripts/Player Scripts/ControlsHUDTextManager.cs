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

    public void TriggerTimer()
    {
        StartCoroutine(HealthUITimer());
    }

    IEnumerator HealthUITimer()
    {
        Health.color = new Color(Health.color.r, Health.color.g, Health.color.b, 1);
        yield return new WaitForSeconds(3f);
        Health.color = new Color(Health.color.r, Health.color.g, Health.color.b, 0);
    }
}
