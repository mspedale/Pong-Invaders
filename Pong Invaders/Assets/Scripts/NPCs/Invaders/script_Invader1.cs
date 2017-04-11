using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Invader1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Projectile_p1") {
			Destroy (gameObject);
		}
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		
		if (coll.gameObject.tag == "Ball") {
			Destroy (gameObject);
		}
		/*
		if (coll.gameObject.tag == "Projectile_p1") {
			Destroy (gameObject);
		}
		*/
	}
	
}
