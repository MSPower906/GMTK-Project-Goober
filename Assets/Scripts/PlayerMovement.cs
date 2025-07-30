using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Movement Variables")] 
    public float speed = 10;
    public float jumpPower = 300;
    public float shortHopPower = 50;
    public float gravity = 9.81f;
    public float drag = 5;
    public float airControl = 10;
    public bool grounded;

    [Header("Reference Variables")]
    private Rigidbody rigidbody;

    [Header("Momentum Storage")]
    public Vector3 Charge1;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Basic left/right movement/drag
        float moveHorizontal = Input.GetAxis("Horizontal");

        if ((Input.GetAxis("Horizontal") > 0.1|| Input.GetAxis("Horizontal") < -0.1) && grounded)
        {
            rigidbody.velocity = new Vector3(moveHorizontal * speed, rigidbody.velocity.y, rigidbody.velocity.z);
        }
        else if (grounded)
        {
            if (rigidbody.velocity.x > 0)
            {
                rigidbody.velocity = new Vector3(rigidbody.velocity.x - (drag * Time.deltaTime), rigidbody.velocity.y, rigidbody.velocity.z);
            }
            else if (rigidbody.velocity.x < 0)
            {
                rigidbody.velocity = new Vector3(rigidbody.velocity.x + (drag * Time.deltaTime), rigidbody.velocity.y, rigidbody.velocity.z);
            }
        }
        else
        {
            if ((rigidbody.velocity.x < speed && Input.GetAxis("Horizontal") > 0.1 || rigidbody.velocity.x > -speed && Input.GetAxis("Horizontal") < -0.1) && !grounded)
            {
                rigidbody.velocity = new Vector3(rigidbody.velocity.x + (Input.GetAxis("Horizontal") * Time.deltaTime * airControl), rigidbody.velocity.y, rigidbody.velocity.z);
            }
        }

        //Gravity
        if (!grounded)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, (rigidbody.velocity.y - (gravity * Time.deltaTime)), rigidbody.velocity.z);
        }
        else
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
        }

        //Jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rigidbody.AddForce(0, jumpPower, 0);
            grounded = false;
        }
        if (Input.GetButtonUp("Jump") && rigidbody.velocity.y > shortHopPower && !grounded)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, shortHopPower, rigidbody.velocity.z);
        }

        //Momentum Storage
        if (Input.GetButtonDown("Fire1"))
        {
            if (rigidbody.velocity != Vector3.zero && Charge1 == Vector3.zero)
            {
                Charge1 = rigidbody.velocity;
                rigidbody.velocity = new Vector3(0, 0, 0);
            }
            else if (Charge1 != Vector3.zero)
            {
                rigidbody.velocity = Charge1;
                Charge1 = new Vector3(0, 0, 0);
            }
        }
    }
}
