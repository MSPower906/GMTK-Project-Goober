using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    public PlayerMovement player;
    public bool LeftWall;

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Ground Check")
        {
            if (LeftWall)
            {
                player.leftWalled = true;
            }
            else
            {
                player.rightWalled = true;
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Ground Check")
        {
            if (LeftWall)
            {
                player.leftWalled = false;
            }
            else
            {
                player.rightWalled = false;
            }
        }
    }
}
