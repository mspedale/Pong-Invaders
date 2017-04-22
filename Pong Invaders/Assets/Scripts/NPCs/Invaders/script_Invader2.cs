using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Invader2 : MonoBehaviour 
{
    public GameObject projectile;
    GameObject projectileClone;
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
    if(hit[1].transform.gameObject.name!="obj_Invader2") //If the first thing it hits that isn't itself's name is "obj_Invader1"
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
		if (coll.gameObject.tag == "Projectile_p1" || coll.gameObject.tag == "Projectile_p2") 
		{
			Destroy (gameObject);
		}
	}
	
	void OnCollisionEnter2D(Collision2D coll) 
	{
		//destroys the invader if the ball runs into it
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
        projectileClone = Instantiate(projectile, newPosition, Quaternion.identity) as GameObject;
        Destroy(projectileClone, 3);
    }
	
}
