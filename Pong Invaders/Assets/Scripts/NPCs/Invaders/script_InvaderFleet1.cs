using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_InvaderFleet1 : MonoBehaviour {
	
	public Rigidbody2D fleetRB;
	
	public float stepSpeed = 0.5f;
	public int xDir = 1;
	public float stepXsize = 0.25f;
	float stepX = 0f;
	public float stepYsize = 0.5f;
	public int maxRest = 60;
	public int restTime = 60;  // private
	Vector2 currentPosition = new Vector2(0f,0f);
	Vector2 newPosition = new Vector2(0f,0f);
	Vector2 newVelocity = new Vector2(0f,0f);
	Vector2 destination = new Vector2(0f,0f);
	
	void Start () {
		fleetRB = GetComponent<Rigidbody2D>();
		currentPosition = fleetRB.transform.position;
		newPosition = currentPosition;
		destination = fleetRB.transform.position;
	}
	
	
	void Update () {
		currentPosition = fleetRB.transform.position;
		newPosition = currentPosition;
		newVelocity = new Vector2(0f,0f);
		
		// Not at rest
		if (restTime <= 0)
		{
			// X and Y steps
			if(restTime+1 > 0) 
			{
				// If-statement for determining whether next step will run into a wall
				// If it does, make xDir *= -1, and do a StepY
				// If not:
				//StepX();
				print("StepX");
				destination.y = currentPosition.y;
				destination.x = currentPosition.x + stepXsize * xDir;
				
				restTime--;
			}
			
			// X movement
			if (currentPosition.x * xDir < destination.x *  xDir) // Not yet reached destination
			{
				newVelocity.x = stepSpeed * xDir;
			}
			else // Destination reached
			{
				newVelocity.x = 0f;
				newPosition.x = destination.x;
				restTime = maxRest;	
				
				print("X Destination reached");
			}
				
			// Y movement
			if (currentPosition.y > destination.y)   // for InvaderFleet 2, switch to <
			{
				newVelocity.y = -stepSpeed;		// for Invaderfleet 2, make stepSpeed positive
			}
			else // Destination reached
			{
				newVelocity.y = 0f;
				newPosition.y = destination.y;
				// restTime = maxRest;	
				
				print("Y Destination reached");
			}	
		}
		// At rest
		else 
		{
			restTime -= 1;
		}
		
		// Position and velocity update
		fleetRB.transform.position = newPosition;
		fleetRB.velocity = newVelocity;
	}
	
	/*
	void StepX () {
		destination.y = currentPosition.y;
		destination.x = currentPosition.x + stepXsize * xDir;
	}
	*/
	
	void StepY () {
		destination.y = currentPosition.y - stepYsize;  // change to "+ stepYsize" for InvaderFleet 2
		destination.x = currentPosition.x;
	}
}