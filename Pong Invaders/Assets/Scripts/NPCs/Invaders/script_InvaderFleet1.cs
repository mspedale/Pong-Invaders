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
	public float maxRest = 60;
	float restTime = 60;
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
		
		if (restTime <= 0f)
		{
			// If-statement for determining whether next step will run into a wall
			// If it does, make xDir *= -1, and do a StepY
			// If not:
			StepX();
			
			// X movement
			if (currentPosition.x * xDir < destination.x * xDir) 
			{
				newVelocity.x = stepSpeed * xDir;	
			}
			else 
			{
				newVelocity.x = 0f;
				newPosition.x = destination.x;
				restTime = maxRest;
			}
			
			// Y movement
			if (currentPosition.y > destination.y)   // for InvaderFleet 2, switch to <
			{
				newVelocity.y = -stepSpeed;		// for Invaderfleet 2, make stepSpeed positive
			}
			else 
			{
				newVelocity.y = 0f;
				newPosition.y = destination.y;
				restTime = maxRest;
			}	
            
			// Position and velocity update
			fleetRB.transform.position = newPosition;
			fleetRB.velocity = newVelocity;			
		}
		else
		{
			restTime -= 1;
		}	
	}
	
	void StepX () {
		destination.y = currentPosition.y;
		destination.x = currentPosition.x + stepXsize * xDir;
	}
	
	void StepY () {
		destination.y = currentPosition.y - stepYsize;  // change to "+ stepYsize" for InvaderFleet 2
		destination.x = currentPosition.x;
	}
}
