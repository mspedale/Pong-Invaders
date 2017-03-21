using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {
	
	float m_speed = 13;
	GameObject playerProjectileClone;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {		
		
		// movement
        var move = new Vector3(Input.GetAxis("Horizontal"), 0,0);
        transform.position += move * m_speed * Time.deltaTime;
				
	}
}