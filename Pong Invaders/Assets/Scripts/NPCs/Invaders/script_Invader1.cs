using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Handles the "Space Invaders" enemies
public class script_Invader1 : MonoBehaviour 
{
    public GameObject projectile;
    GameObject projectileClone;
    float t;
	// Use this for initialization
	void Start () 
	{
		t = Random.Range(0f, 3f);
	}
	
	// Update is called once per frame
	void Update () 
	{
    //fire weapons
     if (Time.time - t > 3)
			{
    StartCoroutine(shoot());
    t = Time.time;  
    }
		
	}
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		//destroys invader if it is hit by the fighter ship projectile
		if (coll.gameObject.tag == "Projectile_p1" || coll.gameObject.tag == "Projectile_p2") 
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
    IEnumerator shoot() //more firing
    {
        yield return new WaitForSeconds (3);
        projectileClone = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        Destroy(projectileClone, 3);
    }
	
}
