using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class containmentScript : MonoBehaviour
{

	int hp = 10;
	float ballForce = 200f;
	public GameObject prefab_ball;
	Rigidbody2D ballBody;
	
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
    {
		print("triggerEnter");
		
		if (other.gameObject.name == "playerProjectile(Clone)")
        {
			hp -= 1;
			print("projectile1 collision: hp = ");
			print(hp);
			if (hp < 1)
            {
				// obj_ballClone = Instantiate(prefab_ball, transform.position,Quaternion.identity) as GameObject;
				GameObject ball = Instantiate(prefab_ball, transform.position,Quaternion.identity) as GameObject;
				ballBody = ball.GetComponent<Rigidbody2D>();
				ballBody.AddForce(new Vector2(0,-200f));
				Destroy (gameObject);
			}
		}
		
		if (other.gameObject.name == "playerProjectile2(Clone)")
        {
			hp -= 1;
			print("projectile2 collision: hp = ");
			print(hp);
			if (hp < 1)
            {
				GameObject ball = Instantiate(prefab_ball, transform.position,Quaternion.identity) as GameObject;
				ballBody = ball.GetComponent<Rigidbody2D>();
				ballBody.AddForce(new Vector2(0,200f));
				Destroy (gameObject);		
			}
		}
			
	}
}
