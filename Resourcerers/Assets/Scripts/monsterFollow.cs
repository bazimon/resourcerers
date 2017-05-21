using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterFollow : MonoBehaviour {

	public float moveSpeed;
	//public PlayerScript player;
	public GameObject followedObject;
	public Sprite frontSprite;
	public Sprite backSprite;
	public Rigidbody2D rigid;

	// Use this for initialization
	void Start () {
		
		//target = GameObject.FindWithTag("Player").transform; //target the player
	}
	
	// Update is called once per frame
	void Update () {
		//if (moveDirection != Vector3.zero) 
		//{
		//	float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		//	bulletInstance.transform.Rotate (new Vector3(0,0,angle+90));
		//}

		float xMovement = 0;
		float yMovement = 0;
		if (transform.position.x + moveSpeed < followedObject.transform.position.x || transform.position.x - moveSpeed > followedObject.transform.position.x) {
			if (transform.position.x != followedObject.transform.position.x && transform.position.x < followedObject.transform.position.x) {
				xMovement = moveSpeed;
				//transform.position += new Vector3 (moveSpeed, 0, 0);
			} else {
				xMovement = -moveSpeed;
				//transform.position += new Vector3 (-moveSpeed, 0, 0);
			}
		}
		if (transform.position.y + moveSpeed < followedObject.transform.position.y || transform.position.y - moveSpeed > followedObject.transform.position.y) {
			if (transform.position.y != followedObject.transform.position.y && transform.position.y < followedObject.transform.position.y) {
				GetComponent<SpriteRenderer> ().sprite = backSprite;
				yMovement = moveSpeed;
				//transform.position += new Vector3 (0, moveSpeed, 0);
			} else {
				GetComponent<SpriteRenderer> ().sprite = frontSprite;
				yMovement = -moveSpeed; //rigid.MovePosition(new Vector2(0, -moveSpeed) + transform.position);
				//transform.position += new Vector3 (0, -moveSpeed, 0);
			}
		}
		rigid.MovePosition(transform.position + (new Vector3(xMovement, yMovement, 0)));
	}
}
