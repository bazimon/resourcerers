using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterScript : MonoBehaviour {
	public Rigidbody2D rigid;
	// Use this for initialization
	void Start () {
		rigid.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
