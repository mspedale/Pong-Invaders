using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour {
	
	public GameObject obj_player;
	public GameObject obj_player2;
	private playerControl playerControl;
	private playerControl2 playerControl2;
	Rigidbody2D ballRigidBody;
	
	
	/*
	float minSpeedY = 0.5f;
	float maxSpeedY = 5f;
	float velX = 0f;
	float velY = 0f;
	//double velocity = new Vector3(velX,velY,0);
	*/
	
	void Awake () {
		ballRigidBody = gameObject.GetComponent<Rigidbody2D>();
		playerControl = GetComponent<playerControl>();
		playerControl2 = GetComponent<playerControl2>();
	}
	
	void Start () {
	//	velY = -minSpeedY;
	}
	
	
	void Update () {
		// Movement update
		// velocity =(velX,velY,0);
	//	transform.position = new Vector3(0,velY,0);
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		print("collisionEnter2D");
		
		// Imparts horizontal force using velX of paddle
		if (coll.gameObject.name == "obj_player") {
			print("player 1 collision");
			ballRigidBody.AddForce(new Vector2(playerControl.velX,0));
		}
		else if (coll.gameObject.name == "obj_player2") {
			print("player 2 collision");
			ballRigidBody.AddForce(new Vector2(playerControl2.velX,0));
		}
	}
}
