using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
	
	float max_speed = 13f;
	public float velX = 0f;		// variable for imparting x-motion on ball
	GameObject playerProjectileClone;
	
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {		
		// movement
        var move = new Vector3(Input.GetAxis("Horizontal"), 0,0);
		velX = move.x * max_speed * Time.deltaTime;
        transform.position += move * max_speed * Time.deltaTime;
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x,-8,8),transform.position.y,transform.position.z);     slightly offscreen
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6, 6), transform.position.y, transform.position.z);  //clamped onscreen
    }
}