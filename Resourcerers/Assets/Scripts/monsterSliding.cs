using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterSliding : MonoBehaviour {

	public float moveSpeed; //RECCOMENDED: 0.0005
	public float maxSpeed; //RECCOMENDED: 0.0001
	public GameObject followedObject;
	public Sprite frontSprite;
	public Sprite backSprite;
	public Rigidbody2D rigid;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		float xMovement = 0;
		float yMovement = 0;
		if (transform.position.x + moveSpeed < followedObject.transform.position.x || transform.position.x - moveSpeed > followedObject.transform.position.x) {
			if (transform.position.x != followedObject.transform.position.x && transform.position.x < followedObject.transform.position.x) {
				xMovement = moveSpeed;
			} else {
				xMovement = -moveSpeed;
			}
		}
		if (transform.position.y + moveSpeed < followedObject.transform.position.y || transform.position.y - moveSpeed > followedObject.transform.position.y) {
			if (transform.position.y != followedObject.transform.position.y && transform.position.y < followedObject.transform.position.y) {
				GetComponent<SpriteRenderer> ().sprite = backSprite;
				yMovement = moveSpeed;
			} else {
				GetComponent<SpriteRenderer> ().sprite = frontSprite;
				yMovement = -moveSpeed;
			}
		}
		if (rigid.velocity.x < maxSpeed || rigid.velocity.x > -maxSpeed){
			rigid.AddForce (new Vector2 (xMovement, 0));
		}
		if(rigid.velocity.y < maxSpeed || rigid.velocity.y > -maxSpeed) {
			rigid.AddForce (new Vector2 (0, yMovement));
		}

	}
}
