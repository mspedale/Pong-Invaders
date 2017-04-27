using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneFleetScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Destroyes DroneFleet object if it has no children
		if (transform.childCount == 0) 
		{
			Destroy(gameObject);
		}
	}
}
