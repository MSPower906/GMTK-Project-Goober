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

    public Renderer mesh;

    public ControlsHUDTextManager HealthHUD;

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
        HealthHUD.TriggerTimer();
    }

    public void Respawn()
    {
        this.transform.position = Checkpoint;
        currentHealth = maxHealth;

        StartCoroutine(InvulnCooldown());
    }

    IEnumerator InvulnCooldown()
    {
        mesh.material.color = new Color(mesh.material.color.r, mesh.material.color.g, mesh.material.color.b, 0.25f);

        //Prevents instant player death from multiple collisions
        yield return new WaitForSeconds(1f);

        mesh.material.color = new Color(mesh.material.color.r, mesh.material.color.g, mesh.material.color.b, 1);

        invuln = false;
    }
}
