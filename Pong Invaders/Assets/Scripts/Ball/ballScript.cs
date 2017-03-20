using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour {
	
	float minSpeedY = 0.5f;
	float maxSpeedY = 5f;
	float velX = 0f;
	float velY = 0f;
	//double velocity = new Vector3(velX,velY,0);
	
	
	void Start () {
		velY = -minSpeedY;
	}
	
	
	void Update () {
		// Movement update
		// velocity =(velX,velY,0);
		transform.position = new Vector3(0,velY,0);
	}
}
