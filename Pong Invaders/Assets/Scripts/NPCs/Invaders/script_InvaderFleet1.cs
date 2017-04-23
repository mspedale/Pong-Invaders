using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_InvaderFleet1 : MonoBehaviour {
	
	public Rigidbody2D fleetRB;
	
	public float stepSpeed = 1.25f;
	public int xDir = 1;
	public float stepXsize = 0.75f;
	float stepX = 0f;
	public float stepYsize = 0.5f;
	public int maxRest = 60;
	private int restTime = 60;
	Vector2 currentPosition = new Vector2(0f,0f);
	Vector2 newPosition = new Vector2(0f,0f);
	Vector2 newVelocity = new Vector2(0f,0f);
	Vector2 destination = new Vector2(0f,0f);
	
	private static Transform[] childTransform;
	
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
			if(restTime+1 > 0) // if restTime reached 0 in THIS frame
			{
				// If-statement for determining whether next step will run into a wall
					// First, need to determine which space invader is farthest to the right if xDir=1, or to the left if xDir = -1
						// Try http://answers.unity3d.com/questions/594210/get-all-children-gameobjects.html
						// or https://docs.unity3d.com/ScriptReference/Component.GetComponentsInChildren.html
					// Next, need to raycast at (stepXsize + half invader size)  to determine whether another step will cause a collision.
						// try Collider2D.Raycast()?
				childTransform = GetComponentsInChildren<Transform>(false);
				Vector2 curPosition = new Vector2(0f,0f);
				float outermostX = 0;		// used to record the x-position of the outermost invaders
				// For-loop determines the x-position of the farthest Invader
				for (int i = 0; i < childTransform.Length; i++) { 
					curPosition= childTransform[i].position;
					if (curPosition.x * xDir > outermostX * xDir) {
						outermostX = curPosition.x;
					}
				}
				print(outermostX);
				
				
				
				// If it does, make xDir *= -1, and do a StepY
				// else: 
					//StepX
					print("StepX");
					destination.y = currentPosition.y;
					destination.x = currentPosition.x + stepXsize * xDir;
				
				restTime--;	// Decrement restTime so this if-statement doesn't get called indefinitely
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
	
	void StepY () {
		destination.y = currentPosition.y - stepYsize;  // change to "+ stepYsize" for InvaderFleet 2
		destination.x = currentPosition.x;
	}
}