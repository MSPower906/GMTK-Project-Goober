using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    float currentHealth = 2;
    bool invuln;

    public void TakeDamage()
    {
       
        if (invuln)
        {
            return;
        }
        
        invuln = true;
        currentHealth--;

        if(currentHealth < 0)
        {
          //SceneManager.LoadScene();
        }

        StartCoroutine(InvulnCooldown());
    }

    IEnumerator InvulnCooldown()
    {
        //Prevents instant player death from multiple collisions
        yield return new WaitForSeconds(2.5f);
        invuln = false;
    }
}
