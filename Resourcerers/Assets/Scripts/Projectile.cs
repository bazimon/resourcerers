using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float damage;

    private float timer = 1f;

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Wall")
        {
            Debug.Log("IT WORKS");
            Destroy(gameObject);
        }
	}

    void Update()
    {
        Wait();
    }

    void Wait()
    {
        timer = Mathf.Max(0f, timer - Time.deltaTime);
        if (timer == 0)
        {
            Destroy(gameObject);
        }
    }
}
