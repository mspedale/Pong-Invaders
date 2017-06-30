using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_InvaderFleet1 : MonoBehaviour {
	
	public Rigidbody2D fleetRB;
	
	public float stepSpeed = 1.25f;
	public int xDir = 1;
	public float stepXsize = 0.75f;
	//float stepX = 0f;
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
			if(restTime+1 > 0) // if restTime reached 0 on THIS frame
			{
				// If invaderFleet has no children, destroy it.
				if (transform.childCount == 0) 
				{
					Destroy(gameObject);
				}
				
				// Create an array of all invaders in InvaderFleet
				childTransform = GetComponentsInChildren<Transform>(false);
				Vector2 curPosition = new Vector2(0f,0f);
				float outermostX = 0;		// used to record the x-position of the outermost invaders
				
				
				
				// For-loop determines the x-position of the Invader farthest to the right or left, depending on xDir
				for (int i = 0; i < childTransform.Length; i++) { 
					curPosition= childTransform[i].position;
					if (curPosition.x * xDir > outermostX * xDir) {
						outermostX = curPosition.x;
					}
				}
				
				// Raycast at (stepXsize + half invader size)  to determine whether another step will cause a collision.  Collider2D.Raycast()?
				RaycastHit2D[] check = Physics2D.RaycastAll(new Vector2(outermostX,transform.position.y), new Vector2(xDir,0f), stepXsize+1f); //raycast THROUGH the object and return an array of hit
				bool wallAhead = false;
				for (int i=0; i < check.Length; i++) {
					if(check[i].transform.gameObject.tag =="Wall") // Check if a wall is in the raycast
					{
						wallAhead = true;
					}
				}
				
				// Will we run into a wall on the next step?
				if (wallAhead == true) {
					// StepY
					destination.y = currentPosition.y - stepYsize;  // change to "currentPosition.y + stepYsize" for InvaderFleet2
					destination.x = currentPosition.x;
					xDir *= -1;
				}
				else { 
					//StepX
					destination.y = currentPosition.y;
					destination.x = currentPosition.x + stepXsize * xDir;
				}
				restTime--;	// Decrement restTime to -1 so this if-statement doesn't get called infinitely
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
				
				// Y movement
				if (currentPosition.y > destination.y)  // Not yet reached destination // for InvaderFleet2, switch ">" to "<"
				{
					newVelocity.y = -stepSpeed;		// for InvaderFleet2, make stepSpeed positive
				}
				else // Destination reached
				{
					newVelocity.y = 0f;
					newPosition.y = destination.y;
					restTime = maxRest;	
				}	
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
}