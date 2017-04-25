using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyScript : MonoBehaviour {

    public Vector3 receptor = new Vector3(-2.515313f, -9.66f, 0f);
     public Transform target;
    float speed =12f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, receptor, step);
	}
}
