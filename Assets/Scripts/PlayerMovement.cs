using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Movement Variables")] 
    public float speed = 10;
    public float jumpPower = 300;
    public float shortHopPower = 50;
    public float fastFallMultiplier = 2;
    private float fallMultiplier = 1;
    public float gravity = 9.81f;
    public float drag = 5;
    public float airControl = 10;
    public bool grounded;
    public bool jumping;

    [Header("Wall Variables")]
    public bool leftWalled;
    public bool rightWalled;

    [Header("Reference Variables")]
    private Rigidbody rigidbody;
    public Renderer renderer;

    [Header("Momentum Storage")]
    public Vector3 Charge1;
    public Material DefaultColour;
    public Material ChargeColour;

    [Header("Debug")]
    public Vector3 PlayerVelocity;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerVelocity = rigidbody.velocity;

        //Basic left/right movement
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Basically no left input if colliding with left wall or vice versa to prevent wall cling
        if (Input.GetAxis("Horizontal") > 0.1 && grounded && !rightWalled && Mathf.Abs(rigidbody.velocity.x) < speed)
        {
            rigidbody.velocity = new Vector3(moveHorizontal * speed, rigidbody.velocity.y, rigidbody.velocity.z);
        }
        else if (Input.GetAxis("Horizontal") < -0.1 && grounded && !leftWalled && Mathf.Abs(rigidbody.velocity.x) < speed)
        {
            rigidbody.velocity = new Vector3(moveHorizontal * speed, rigidbody.velocity.y, rigidbody.velocity.z);
        }
        //Drag
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
        //No aerial wall cling/aerial drag
        else
        {
            if (rigidbody.velocity.x > -speed && Input.GetAxis("Horizontal") < -0.1 && !leftWalled && !grounded || Input.GetAxis("Horizontal") > 0.1 && grounded && !leftWalled && Mathf.Abs(rigidbody.velocity.x) > speed)
            {
                rigidbody.velocity = new Vector3(rigidbody.velocity.x + (Input.GetAxis("Horizontal") * Time.deltaTime * airControl), rigidbody.velocity.y, rigidbody.velocity.z);
            }

            if (rigidbody.velocity.x < speed && Input.GetAxis("Horizontal") > 0.1 && !rightWalled && !grounded || Input.GetAxis("Horizontal") < -0.1 && grounded && !rightWalled && Mathf.Abs(rigidbody.velocity.x) > speed)
            {
                rigidbody.velocity = new Vector3(rigidbody.velocity.x + (Input.GetAxis("Horizontal") * Time.deltaTime * airControl), rigidbody.velocity.y, rigidbody.velocity.z);
            }
        }

        //Gravity
        if (!grounded)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, (rigidbody.velocity.y - ((gravity * Time.deltaTime) * fallMultiplier)), rigidbody.velocity.z);
        }
        else if (rigidbody.velocity.y < 0)
        {
            if (Input.GetAxis("Vertical") < -0.1 && !jumping)
            {
                rigidbody.velocity = new Vector3(rigidbody.velocity.x, -10, rigidbody.velocity.z);
            }
            else if (!jumping)
            {
                rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
            }
        }

        //Fastfall
        if (Input.GetAxis("Vertical") < -0.1)
        {
            fallMultiplier = fastFallMultiplier;
        }
        else
        {
            fallMultiplier = 1;
        }

        //Jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
            StartCoroutine(JumpTimer());
            if (Mathf.Abs(rigidbody.velocity.x) > speed)
            {
                rigidbody.velocity = new Vector3(rigidbody.velocity.x, (jumpPower + (Mathf.Abs(rigidbody.velocity.x - speed) / 2)), rigidbody.velocity.z);
            }
            else
            {
                rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpPower, rigidbody.velocity.z);
            }

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
                renderer.material = ChargeColour;            }
            else if (Charge1 != Vector3.zero)
            {
                rigidbody.velocity = Charge1;
                Charge1 = new Vector3(0, 0, 0);
                renderer.material = DefaultColour;
            }
        }
    }

    IEnumerator JumpTimer()
    {
        jumping = true;
        yield return new WaitForSeconds(0.1f);
        jumping = false;
    }
}
