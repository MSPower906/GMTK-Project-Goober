using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineScript : MonoBehaviour
{
    [SerializeField] private float launchPower = 20;
    [SerializeField] private float maxPower = 40;
    private bool onCoolDown = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "GroundChecker" && !onCoolDown)
        {
            Rigidbody rb = other.gameObject.transform.GetComponentInParent<Rigidbody>();
            onCoolDown = true;

            if (rb.velocity.y <= -launchPower && !(rb.velocity.y < -maxPower))
            {
                rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, rb.velocity.z);
                Debug.Log("Momentum Carried!");
            }
            else if (rb.velocity.y > -launchPower)
            {
                rb.velocity = new Vector3(rb.velocity.x, launchPower, rb.velocity.z);
                Debug.Log("Minimum bounce");
            }

            if (rb.velocity.y < -maxPower && !(rb.velocity.y > -launchPower))
            {
                rb.velocity = new Vector3(rb.velocity.x, maxPower, rb.velocity.z);
                Debug.Log("Max boost given!");
            }

            StartCoroutine(JumpCooldown());
        }
    }

    IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(0.2f);
        onCoolDown = false;
    }
}
