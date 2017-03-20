using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour {
	
	double minSpeedY = 0.2;
	double maxSpeedY = 5;
	double velX = 0;
	double velY = 0;
	
	
	void Start () {
		velY = -minSpeedY;
	}
	
	
	void Update () {
		// Movement update
	}
}
