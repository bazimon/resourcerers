using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]

public class PlayerScript : MonoBehaviour{

    public GameObject hand;
    public float moveSpeed = 3f;
    public float dodgeSpeed = 5f;
    public float dodgeTime = 0.3f;
    public float dodgeSlowTime = 0.2f;
    public float dodgeSlowSpeed = 2f;

    private bool colliding = false;
    private bool dodging = false;
    private float dodgeTimer = 0;
    private float dodgeH = 0;
    private float dodgeV = 0;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody;
    private Animator anim;
    private Animator animHand;
    private ShootScript shootScript;

    private float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
    {
        Vector2 diference = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, diference) * sign;
    }
    private Vector3 GetMousePosition()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = transform.position.z - Camera.main.transform.position.z;
        return pos;
    }


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        shootScript = GetComponent<ShootScript>();
        //if (hand) { animHand.GetComponent<Animator>();  }
    }

    private void FixedUpdate()
    {

        if (dodging)
        {
            Dodge();
        }
        else
        {
            Movement(moveSpeed);
        }
        MovementHand();
    }

    private void Update()
	{
		TimerCountdown ();
		if (Input.GetButtonDown ("Fire1")) {
			shootScript.Shoot (0, 0);
		}
		if (Input.GetButtonDown ("Fire2")) {

		}
		if (Input.GetButtonDown ("Jump") && !dodging) {
			anim.SetInteger ("State", 2);
			dodgeH = Input.GetAxisRaw ("Horizontal");
			dodgeV = Input.GetAxisRaw ("Vertical");
			dodgeTimer = dodgeTime;
			dodging = true;
		}
	}

    private void Movement(float speed)
    {
        Vector3 dir = new Vector3(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical"));
        Vector2 pos = Camera.main.WorldToScreenPoint(this.transform.position);

        //Switches the player from Idle and Move
        if (dir != Vector3.zero){
            anim.SetInteger("State", 1);
        } else {
            anim.SetInteger("State", 0);
        }

        //Flip player when mouse is on X opposite side
        if (Input.mousePosition.x < pos.x) {  
            spriteRenderer.flipX = false;
        } else {
            spriteRenderer.flipX = true;
        }

        //Change facing direction when mouse is on Y opposite side
        if (Input.mousePosition.y < pos.y)
        {
            anim.SetBool("Facing", false);
            spriteRenderer.sortingLayerName = "Actor Front";
        } else {
            anim.SetBool("Facing", true);
            spriteRenderer.sortingLayerName = "Actor Back";
        }

        rigidbody.MovePosition(transform.position + (dir * speed) * Time.deltaTime);
    }

    private void MovementHand()
    {
        if (hand)
        {
            float rad = 2;
            float angle = AngleBetweenVector2(GetMousePosition(), transform.position);
            Vector2 pos = Camera.main.WorldToScreenPoint(this.transform.position);
            Vector3 dir = GetMousePosition() - transform.position;

            dir = Vector3.ClampMagnitude(dir, rad);
            hand.transform.position = transform.position + dir;
            hand.transform.eulerAngles = new Vector3(0,0,angle+90);

            if (Input.mousePosition.x < pos.x)
            {
                hand.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                hand.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }

    private void Dodge()
    {
        Vector3 dir = new Vector3(dodgeH, dodgeV);
        if (dodgeTimer >= dodgeSlowTime)
        {
            rigidbody.MovePosition(transform.position + (dir * dodgeSpeed) * Time.deltaTime);
        }
        else
        {
            rigidbody.MovePosition(transform.position + (dir * dodgeSlowSpeed) * Time.deltaTime);
        }
    }

    private void TimerCountdown()
    {
        dodgeTimer = Mathf.Max(0f, dodgeTimer - Time.deltaTime);
        if (dodgeTimer == 0) {
            dodging = false;
        }
    }
}