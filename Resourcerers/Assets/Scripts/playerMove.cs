using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]

public class playerMove : MonoBehaviour{

    public float speed = 2.5f;
    public float dodgeSpeed = 4f;
    public float dodgeTime = 0.4f;

    private bool dodging = false;
    private float dodgeTimer = 0;
    private float dodgeH = 0;
    private float dodgeV = 0;
    private Rigidbody2D rigidbody;
    private Animator anim;
    private Vector2 targetVelocity;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    void FixedUpdate()
    {

        if (dodging)
        {
            Dodge();
        }
        else
        {
            Movement();
            if (Input.GetKey(KeyCode.LeftShift) && !dodging)
            {
                dodgeH = Input.GetAxisRaw("Horizontal");
                dodgeV = Input.GetAxisRaw("Vertical");
                dodgeTimer = dodgeTime;
                dodging = true;
            }
        }
    }

    void Movement()
    {
        
        targetVelocity = new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical"));
        if (targetVelocity != Vector2.zero)
        {
            anim.SetInteger("State", 1);
        }
        else
        {
            anim.SetInteger("State", 0);
        }
        rigidbody.velocity = targetVelocity * speed;
    }

    void Dodge()
    {
        dodgeTimer = Mathf.Max(0f, dodgeTimer - Time.deltaTime);

        targetVelocity = new Vector2(dodgeH, dodgeV);
        rigidbody.velocity = targetVelocity * dodgeSpeed;

        if (dodgeTimer == 0)
        {
            dodging = false;
        }
    }
}