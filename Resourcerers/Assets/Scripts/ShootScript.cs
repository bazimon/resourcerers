using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour {


    public GameObject[] projectileSpawn;
    public GameObject[] projectile;
    public int damage;
    public float speed;
    public float cooldown;
    public bool continuous;

    private float timer;

    private void TimerCountdown()
    {
        timer = Mathf.Max(0f, timer - Time.deltaTime);
    }

    private void Start()
    {
        if (projectileSpawn == null) { projectileSpawn[0] = this.gameObject; }
    }

	public void Shoot (int spawnLoc, int bulletType)
    {
        if (timer == 0)
        {
            timer = cooldown;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dir = (Vector2)((mousePos - transform.position));
            dir.Normalize();

            GameObject bulletInstance = Instantiate(projectile[bulletType], projectileSpawn[spawnLoc].transform.position, Quaternion.identity);
            Projectile projectileScript = bulletInstance.GetComponent<Projectile>();

            Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            //projectileScript.velocity = dir * speed;
            projectileScript.SetSpeed(speed);
            projectileScript.SetSpeedDir(dir);
			projectileScript.SetRotation (dir);
			projectileScript.damage = damage;
        }
    }

    private void Update()
    {
        TimerCountdown();
    }

    
}
