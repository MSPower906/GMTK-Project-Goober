using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointUpdate : MonoBehaviour
{
    public Material FlagMaterial;
    public Renderer Flag;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<HealthScript>().Checkpoint = this.transform.position;
            collision.GetComponent<HealthScript>().currentHealth = collision.GetComponent<HealthScript>().maxHealth;

            Flag.material = FlagMaterial;
        }
    }
}
