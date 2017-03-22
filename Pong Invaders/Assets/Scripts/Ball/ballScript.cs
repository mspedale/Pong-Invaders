using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour {
	
	public GameObject obj_player;
	public GameObject obj_player2;
	private playerControl playerControl;
	private playerControl2 playerControl2;
	Rigidbody2D ballRigidBody;
	public float reflectionAngle;
	public float deadZone;
	private float activeZoneLeft, activeZoneRight;
	private float currentVelocity;
	
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
	currentVelocity = Mathf.Sqrt(Mathf.Pow(ballRigidBody.velocity.x,2)+Mathf.Pow(ballRigidBody.velocity.y,2));
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		//print("collisionEnter2D");
		
		// Imparts horizontal force using velX of paddle
		/*
		if (coll.gameObject.name == "obj_player") {
			print("player 1 collision");
			ballRigidBody.AddForce(new Vector2(coll.gameObject.GetComponent<playerControl>().velX,0));
		}
		else if (coll.gameObject.name == "obj_player2") {
			print("player 2 collision");
			ballRigidBody.AddForce(new Vector2(coll.gameObject.GetComponent<playerControl2>().velX,0));
		}
		*/
		if(coll.gameObject.name == "obj_player" || coll.gameObject.name == "obj_player2") {
			float leftBound = coll.transform.position.x-coll.transform.lossyScale.x/2;
			float rightBound = coll.transform.position.x+coll.transform.lossyScale.x/2;
			float contactPoint = coll.contacts[0].point.x;
			float contactNormal = ((rightBound - leftBound)-(contactPoint - leftBound))/coll.transform.lossyScale.x;
			bool inDeadzone = false;
			//deadzone implementation
			float liveZone = 0.5f-deadZone/2;
			float correctedContactNormal;

			if(contactNormal > 0.5-deadZone/2 && contactNormal < 0.5+deadZone/2) {
				inDeadzone = true;
			} else if(contactNormal <= 0.5-deadZone/2){
				correctedContactNormal = contactNormal/liveZone/2;
				contactNormal = correctedContactNormal;
			} else {
				correctedContactNormal = 0.5f+(contactNormal-(0.5f+deadZone/2))/liveZone/2;
				contactNormal = correctedContactNormal;
			}
			////
			float newDirection = (180-reflectionAngle)/2 + reflectionAngle*contactNormal;
			float newDirectionRadians = newDirection * Mathf.PI/180;
			float newX = Mathf.Cos(newDirectionRadians)*Mathf.Abs(currentVelocity);
			float newY = 0;
			if(coll.gameObject.name == "obj_player")
				newY = Mathf.Sin(newDirectionRadians)*Mathf.Abs(currentVelocity+0.25f);
			else if(coll.gameObject.name == "obj_player2")
				newY = -Mathf.Sin(newDirectionRadians)*Mathf.Abs(currentVelocity+0.25f);
			if(!inDeadzone)
				ballRigidBody.velocity = new Vector2(newX,newY);
		}
	}
}
