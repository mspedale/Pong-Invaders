using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Handles gun behavior for player 1
public class gunScript : MonoBehaviour
{

    public GameObject playerProjectile;
    GameObject playerProjectileClone;
	float t = 0;

    //audio
    AudioSource proj_sound1;

    // Update is called once per frame
    void Update()
    {
        // projectile firing
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time - t > .5)
			{
				//audio
				gameObject.GetComponent<AudioSource>().Play();

                playerProjectileClone = Instantiate(playerProjectile, transform.position, Quaternion.identity) as GameObject;
                Destroy(playerProjectileClone, 3);
                t = Time.time;  // probably why the pause isn't stopping this, I used Time.timescale
            }
        }
    }
}