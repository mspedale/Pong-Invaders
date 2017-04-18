using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Handles the "Space Invaders" enemies
public class script_Invader1 : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		//destroys invader if it is hit by the fighter ship projectile
		if (coll.gameObject.tag == "Projectile_p1") 
		{
			Destroy (gameObject);
		}
	}
	
	void OnCollisionEnter2D(Collision2D coll) 
	{
		//destroys the ball if an invader runs into it
		if (coll.gameObject.tag == "Ball")
		{
			Destroy (gameObject);
		}

		/*
		if (coll.gameObject.tag == "Projectile_p1") 
		{
			Destroy (gameObject);
		}
		*/
	}
	
}
