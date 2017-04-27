using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		// Shield deactivates upon contact with the ball
		if(other.gameObject.tag=="Ball")
		{
			gameObject.SetActive(false);
		}
	}
}
