using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollisionCheck : MonoBehaviour
{
    public PlayerMovement player;

    private void OnTriggerStay(Collider collision)
    {
        player.grounded = true;
    }

    private void OnTriggerExit(Collider collision)
    {
        player.grounded = false;
    }
}
