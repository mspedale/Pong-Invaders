using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Invader2 : MonoBehaviour 
{
    public GameObject projectile;
    GameObject projectileClone;
    public GameObject energy;
    public GameObject energy2;
    float t;
    Vector3 newPosition;

	// Use this for initialization
	void Start () 
	{
		t = Random.Range(0f, 3f);
	}
	
	// Update is called once per frame
	void Update () 
	{
    //fire weapons
     newPosition = transform.position;
    Vector3 eps = new Vector3(0f,.05f,0f);
    newPosition = newPosition + eps;
    
    RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2.up); //raycast THROUGH the object and return an array of hits
    if(hit[1].transform.gameObject.tag!="invader"&& hit[1].transform.gameObject.name!="InvaderProjectile1(Clone)") //If the first thing it hits that isn't itself's name is "obj_Invader1"
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
		if (coll.gameObject.name == "playerProjectile(Clone)" || coll.gameObject.name == "blueProjectile(Clone)" )
            {
                Instantiate(energy, newPosition, Quaternion.identity);
				Destroy (gameObject);
			}
			
			// Player Two (top) gets last shot
			else if (coll.gameObject.name == "playerProjectile2(Clone)" ||coll.gameObject.name == "redProjectile(Clone)")
            {
                Instantiate(energy2, newPosition, Quaternion.identity);
				Destroy (gameObject);		
			}
	}
	
	void OnCollisionEnter2D(Collision2D coll) 
	{
		//destroys the invader if the ball runs into it
		if (coll.gameObject.tag == "Ball" || coll.gameObject.tag == "Player2")
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

    IEnumerator shoot() //more firing
    {
        yield return new WaitForSeconds (3);
        projectileClone = Instantiate(projectile, newPosition, Quaternion.identity) as GameObject;
        Destroy(projectileClone, 3);
    }
	
}
