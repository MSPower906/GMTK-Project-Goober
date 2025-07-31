using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    #region variables
    [SerializeField] private bool inRange;
    [SerializeField] private GameObject barrel;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float launchPower;
    #endregion


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }
    //Simple collsion check
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }

    private void Update()
    {
        if(inRange && Input.GetButtonDown("Fire2")) //fires using RMB
        {
            LaunchPlayer();
        }
    }

    //Sets the bool to false to prevent spamming, sets the players position to give the same result each time.
    //launches the player depending on the rotation of the cannon barrel.
    void LaunchPlayer()
    {
        inRange = false;
        rb.gameObject.transform.position = gameObject.transform.position; 
        rb.velocity = barrel.transform.up * launchPower;
    }
}
