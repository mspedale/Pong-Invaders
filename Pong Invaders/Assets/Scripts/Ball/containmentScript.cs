using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class containmentScript : MonoBehaviour {

	int hp = 10;
	float ballForce = 200f;
	public GameObject prefab_ball;
	Rigidbody2D ballBody;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// Collision event (hopefully just with player projectiles)
	void OnTriggerEnter2D(Collider2D other) {
		hp -= 1;
		print(hp);
		
		// HP down to 0
		if (hp < 1) {
			// Player One (bottom) gets last shot
			if (other.gameObject.name == "playerProjectile(Clone)") {
				GameObject ball = Instantiate(prefab_ball, transform.position,Quaternion.identity) as GameObject;
				ballBody = ball.GetComponent<Rigidbody2D>();
				ballBody.AddForce(new Vector2(0,-ballForce));
				Destroy (gameObject);
			}
			
			// Player Two (top) gets last shot
			else if (other.gameObject.name == "playerProjectile2(Clone)") {
				GameObject ball = Instantiate(prefab_ball, transform.position,Quaternion.identity) as GameObject;
				ballBody = ball.GetComponent<Rigidbody2D>();
				ballBody.AddForce(new Vector2(0,ballForce));
				Destroy (gameObject);		
			}
		}
	}
}
