using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class clonerScript : MonoBehaviour {

public GameObject playerProjectile;
GameObject playerProjectileClone;

	// Update is called once per frame
	void Update () {
		// projectile firing
		if (Input.GetButton("Fire1")) {
			playerProjectileClone = Instantiate(playerProjectile, transform.position,Quaternion.identity) as GameObject;
		}
	}
}