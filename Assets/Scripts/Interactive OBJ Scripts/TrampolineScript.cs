using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineScript : MonoBehaviour
{
    [SerializeField] private float launchPower = 20;
    private bool onCoolDown = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "GroundChecker" && !onCoolDown)
        {
            Rigidbody rb = other.gameObject.transform.GetComponentInParent<Rigidbody>();
            onCoolDown = true;
            rb.AddForce(0, launchPower /* (-rb.velocity.y * 0.4f)*/, 0, ForceMode.Impulse);
            StartCoroutine(JumpCooldown());
        }
    }

    IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(0.2f);
        onCoolDown = false;
    }
}
