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
	Vector3 currentPosition = new Vector3(0f,0f,0f);
	Vector3 newPosition = new Vector3(0f,0f,0f);
	
	void Start () {
		fleetRB = GetComponent<Rigidbody2D>();
		currentPosition = fleetRB.transform.position;
		newPosition = fleetRB.transform.position;	
	}
	
	
	void Update () {
		currentPosition = fleetRB.transform.position;
		
		if (restTime <= 0f)
		{
			// If statement for determining whether next step will run into a wall
			// If it does, make xDir *= -1, and do a StepY
			// If not:
			StepX();
			
			// X movement (killing compile)
            /*
			if (currentPosition.x * xDir < newPosition.x * xDir) 
			{
				fleetRB.velocity.x = stepSpeed * xDir;	
			}
			else 
			{
				fleetRB.velocity.x = 0f;
				fleetRB.transform.position.x = newPosition.x;
				restTime = maxRest;
			}
			
			// Y movement
			if (currentPosition.y > newPosition.y)   // for InvaderFleet 2, switch to <
			{
				fleetRB.velocity.y = -stepSpeed;		// for Invaderfleet 2, make stepSpeed positive
			}
			else 
			{
				fleetRB.velocity.y = 0f;
				fleetRB.transform.position.y = newPosition.y;
				restTime = maxRest;
			}	
            */
		}
		else
		{
			restTime -= 1;
		}
		
		
		
	}
	
	void StepX () {
		newPosition.y = currentPosition.y;
		newPosition.x = currentPosition.x + stepXsize * xDir;
	}
	
	void StepY () {
		newPosition.y = currentPosition.y - stepYsize;  // change to "+ stepYsize" for InvaderFleet 2
		newPosition.x = currentPosition.x;
	}
}
