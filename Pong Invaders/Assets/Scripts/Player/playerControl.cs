using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {
	
	float max_speed = 13f;
	float velX = 0f;
	GameObject playerProjectileClone;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {		
		
		// movement
        var move = new Vector3(Input.GetAxis("Horizontal"), 0,0);
        transform.position += move * max_speed * Time.deltaTime;				
	}
}