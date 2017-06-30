using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Handles the "Space Invader" enemies
public class script_Invader1 : MonoBehaviour 
{
    public GameObject projectile;
    GameObject projectileClone;
	public GameObject deathExplosion;
	GameObject smallExplosionClone;
    public GameObject energy;
    public GameObject energy2;
    float t;
    Vector3 newPosition;

	// Initialization
	void Start () 
	{
		t = Random.Range(0f, 3f);
	}
	
	// Update is called once per frame
	void Update () 
	{
    //fire weapons
     newPosition = transform.position;
    Vector3 eps = new Vector3(0f,-.05f,0f);
    newPosition = newPosition + eps;
    
	//raycast THROUGH the object and return an array of hits
    RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2.down); 
		
		// Check whether an invader is in front of this one.  If so, don't fire weapons.
		if(hit[1].transform.gameObject.tag!="invader" && hit[1].transform.gameObject.name!="InvaderProjectile1(Clone)") //If the first thing it hits that isn't itself's name is "obj_Invader1"
        {
        if (Time.time - t > 3f)
			{
                StartCoroutine(shoot());
                t = Time.time;  
            }
		}
		
	}
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		//destroys invader if it is hit by the fighter ship projectile
		if (coll.gameObject.name == "playerProjectile(Clone)" || coll.gameObject.name == "blueProjectile(Clone)")
            {
                Instantiate(energy, newPosition, Quaternion.identity);
				Destroy();
				//StartCoroutine(destroy());
			}
			
			// Player Two (top) gets last shot
			else if (coll.gameObject.name == "playerProjectile2(Clone)" || coll.gameObject.name == "blueProjectile(Clone)")
            {
                Instantiate(energy2, newPosition, Quaternion.identity);
				Destroy();
				//StartCoroutine(destroy());		
			}
	}
	
	void OnCollisionEnter2D(Collision2D coll) 
	{
		//destroys the invader if the ball runs into it
		if (coll.gameObject.tag == "Ball" || coll.gameObject.tag == "Player1")
		{
			Destroy();
			//StartCoroutine(destroy());
		}

		/*
		if (coll.gameObject.tag == "Projectile_p1") 
		{
			Destroy (gameObject);
		}
		*/
	}
	
	
	// Death Function
	/*
	IEnumerator destroy() 
	{
		yield return new WaitForSeconds (0);
		smallExplosionClone = Instantiate(deathExplosion, newPosition, Quaternion.identity) as GameObject;
		Destroy (gameObject);
	}
	*/
	
	void Destroy() {
		smallExplosionClone = Instantiate(deathExplosion, newPosition, Quaternion.identity) as GameObject;
		Destroy (gameObject);
	}
	
	
    IEnumerator shoot() //more firing
    {
        yield return new WaitForSeconds (3);
        projectileClone = Instantiate(projectile, newPosition, Quaternion.identity) as GameObject;
        Destroy(projectileClone, 3);
    }
	
}
