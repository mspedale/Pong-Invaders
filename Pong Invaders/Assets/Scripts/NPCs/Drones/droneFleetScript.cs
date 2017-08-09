using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneFleetScript : MonoBehaviour {


	private static Transform[] droneSlot;
	private int slotCount = 0;
	
	// Use this for initialization
	void Start () 
	{
		// fill array with child slot objects
		droneSlot = GetComponentsInChildren<Transform>(false);
		
		// Set slotCount
		slotCount = gameObject.childCount;
	}
	
	// Update is called once per frame
	void Update () {
		// Destroyes DroneFleet object if it has no children
		if (transform.childCount == 0) 
		{
			Destroy(gameObject);
		}
	}
	
	// Method for spawning a new fleet of drones
	public void fleetSpawn() {
		// determine which slots are inactive
		// spawn drones according to a timer
	}
	
	// Method for spawning a drone (for use in fleetSpawn()
	private void droneSpawn() {
		// spawn a drone
		// set drone as child of chosen slot
	}
}
