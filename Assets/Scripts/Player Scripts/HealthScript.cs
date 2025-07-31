using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    public Vector3 Checkpoint;
    public float currentHealth = 2;
    public float maxHealth = 2;
    bool invuln;

    private void Start()
    {
        Checkpoint = this.transform.position;
    }

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
            this.transform.position = Checkpoint;
            currentHealth = maxHealth;
        }

        StartCoroutine(InvulnCooldown());
    }

    public void Respawn()
    {
        this.transform.position = Checkpoint;
        currentHealth = maxHealth;

        StartCoroutine(InvulnCooldown());
    }

    IEnumerator InvulnCooldown()
    {
        GetComponent<Renderer>().material.color = new Color(GetComponent<Renderer>().material.color.r, GetComponent<Renderer>().material.color.g, GetComponent<Renderer>().material.color.b, 0.25f);

        //Prevents instant player death from multiple collisions
        yield return new WaitForSeconds(2.5f);

        GetComponent<Renderer>().material.color = new Color(GetComponent<Renderer>().material.color.r, GetComponent<Renderer>().material.color.g, GetComponent<Renderer>().material.color.b, 1);

        invuln = false;
    }
}
