using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathScript : MonoBehaviour {

public GameObject ContainmentPrefab;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
void OnTriggerEnter2D(Collider2D other){

    if (other.gameObject.name == "prefab_ball") {

        Destroy (other.gameObject);
        GameObject Containment = Instantiate(ContainmentPrefab, new Vector2(0,0), Quaternion.identity) as GameObject;
			}
}
}