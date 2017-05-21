using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public int damage;
    public float speed;

	//Element Side Effects
	public bool piercing; //Goes through enemies
	public float pushback; //

    private float timer = 3f;
    private Vector3 dir;

    private void TimerCountdown()
    {
        timer = Mathf.Max(0f, timer - Time.deltaTime);
        if (timer == 0) { Destroy(gameObject); }
    }

    private void Start()
    {
        //GetComponent<Rigidbody2D>().velocity = dir * speed;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
        TimerCountdown();
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
        case "Wall":
			Destroy(gameObject);
			break;
		case "Enemy":
            //Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
			HealthScript healthScript = col.gameObject.GetComponent<HealthScript> ();
			healthScript.TakeDamage (damage);
			if (!piercing) {
				Destroy (gameObject);
			}
            break;
        }
    }

    private void Movement()
    {
        GetComponent<Rigidbody2D>().MovePosition(transform.position + (dir * speed) * Time.deltaTime);
    }

    public void SetSpeed(float speed) { this.speed = speed; }
    public void SetSpeedDir(Vector2 dir) { this.dir = dir; }
	public void SetRotation(Vector2 dir){
		//Vector3 moveDirection = mousePos - transform.position; 
		if (dir != Vector2.zero) 
		{
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.Rotate (new Vector3(0,0,angle+90));
		}
	}
}
