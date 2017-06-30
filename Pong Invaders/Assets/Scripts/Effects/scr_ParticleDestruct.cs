using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ParticleDestruct : MonoBehaviour {

	private ParticleSystem ps;
	
	// Use this for initialization
	void Start () {
		ps = GetComponent<ParticleSystem>();
		
		Destroy(gameObject, ps.duration);
	}
	
	/*
	// Update is called once per frame
	void Update () {
		
	}
	*/
}	
