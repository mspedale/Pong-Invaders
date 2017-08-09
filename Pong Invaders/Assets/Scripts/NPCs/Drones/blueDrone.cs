using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueDrone : MonoBehaviour {
    
	GameObject droneFleet;	// parent parent droneFleet object
	GameObject droneSlot;	// parent droneSlot object
	public GameObject projectile;
    GameObject projectileClone;
	public GameObject deathExplosion;
	GameObject smallExplosionClone;
	
	public float speedX = 0.2f;
	public float speedY = 0.5f;
	
	private Vector2 formPoint = new Vector2(0,0);  // Position in fleet formation
	private float y1;  // This is the y position at which the drone maneuvers to match the x-position of its formPoint.  Set equal to the Y of the droneFleet object.  
						// Should be set BEHIND mothership shield
    float t;
    Vector3 shotPosition;
	Vector2 curPosition;
	Vector2 newPosition;
	
	// Use this for initialization
	void Start () 
	{
		t = Random.Range(0f, 3f);
		droneSlot = transform.parent.gameObject;
		formPoint = droneSlot.transform.position;
		droneFleet = droneSlot.transform.parent.gameObject;
		Vector2 fleetPosition = droneFleet.transform.position;
		y1 = fleetPosition.y;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//fire weapons  (Jonah's code.  Not sure wtf this does.)
		 shotPosition = transform.position;
		Vector3 eps = new Vector3(0f,.05f,0f);
		shotPosition = shotPosition + eps;
		
		
		// If in formation position, shoot
		if (curPosition == formPoint)
		{
			// Check to see if the player is in front of the drone before shooting.  (Jonah's code)
			RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2.up); //raycast THROUGH the object and return an array of hits
			if(hit[1].transform.gameObject.name!="obj_player") //If the first thing it hits that isn't itself's name is "obj_player"
			{
				if (Time.time - t > 3f)
					{
						StartCoroutine(shoot());
						t = Time.time;  
					}
			}
		}
		// If NOT in formation position, move to it
		else 
		{
			newPosition = transform.position;
			
			// Algorithm for movement into position
			// If not yet at horizontal movement point
			if (transform.position.y < y1)   // for player 2:  if (transform.position.y > y1)
			{
				newPosition.y += speedY;	// for player 2: newPosition.y -= speedY;
			}
			// Horizontal movement
			else 
			{
				float xDif = formPoint.x - transform.position.x;		// x-displacement from formPoint
				// if not at formPoint x-position
				if (xDif != 0)
					newPosition.x += speedX * Mathf.Sign(xDif);	// move left/right to formPoint.  Use sign of xDif to indicate direction.
				// if not at formPoint y-position, vertical movement
				else if (transform.position.y < formPoint.y)	// for player 2:  else if (transform.position.y > formPoint.y)
					newPosition.y += speedY;   // move to match formPoint.y
			}
			transform.position = newPosition;
		}
	}
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		//destroys invader if it is hit by the fighter ship projectile
		if (coll.gameObject.tag == "Projectile_p2" || coll.gameObject.name=="InvaderProjectile1(Clone)" || coll.gameObject.name == "redProjectile(Clone)") 
		{
			Destroy();
		}
	}
	
	void OnCollisionEnter2D(Collision2D coll) 
	{
		//destroys the ball if an invader runs into it
		if (coll.gameObject.tag == "Ball")
		{
			Destroy();
		}

		/*
		if (coll.gameObject.tag == "Projectile_p1") 
		{
			Destroy();
		}
		*/
	}
	
    IEnumerator shoot() //more firing
    {
        yield return new WaitForSeconds (3);
        projectileClone = Instantiate(projectile, shotPosition, Quaternion.identity) as GameObject;
        Destroy(projectileClone, 3);
    }
	
	void Destroy() {
		smallExplosionClone = Instantiate(deathExplosion, shotPosition, Quaternion.identity) as GameObject;
		Destroy (gameObject);
	}
	
	// Methods for telling the drone its formation position
	void SetFormPoint(Vector2 newPoint) {
		formPoint = newPoint;
	}

	void SetFormPoint(float x, float y) {
		formPoint = new Vector2(x,y);
	}

	void SetFormPointX(float x) {
		formPoint = new Vector2(x, formPoint.y);
	}

	void SetFormPointY(float y) {
		formPoint = new Vector2(formPoint.x, y);
	}
}