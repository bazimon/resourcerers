using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour {

    public GameObject projectile;
    public GameObject deathParticle;
    public float speed;
    public float damage;

    private Vector3 mousePos;
    private Vector2 dir;
    private GameObject bulletInstance;
    
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dir = (Vector2)((mousePos - transform.position));
            dir.Normalize();
            bulletInstance = Instantiate(projectile, transform.position, Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().velocity = dir * speed;
            bulletInstance.GetComponent<Projectile>().damage = this.damage;

			Vector3 moveDirection = mousePos - transform.position; 
			if (moveDirection != Vector3.zero) 
			{
				float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
				bulletInstance.transform.Rotate (new Vector3(0,0,angle+90));
			}
				
        }
	}
}
