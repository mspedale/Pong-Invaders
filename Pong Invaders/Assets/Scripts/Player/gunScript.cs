using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class gunScript : MonoBehaviour {

public GameObject playerProjectile;
GameObject playerProjectileClone;
float t=0;

	// Update is called once per frame
	void Update () {
		// projectile firing
		if (Input.GetButtonDown("Fire1")) {
            if(Time.time-t>.5){
			playerProjectileClone = Instantiate(playerProjectile, transform.position,Quaternion.identity) as GameObject;
            Destroy(playerProjectileClone, 3);
                t=Time.time;
            }
		}
            
	}
}

