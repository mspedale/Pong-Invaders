using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyScript2 : MonoBehaviour {
    public Vector3 receptor = new Vector3(0f, 14f, 0f);
    public Transform target;
    float speed =10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		speed += 1f;
		float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, receptor, step);
	}
}
