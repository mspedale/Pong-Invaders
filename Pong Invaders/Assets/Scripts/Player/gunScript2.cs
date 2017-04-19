using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Handles gun behavior for player 2
public class gunScript2 : MonoBehaviour
{

    public GameObject playerProjectile2;
    GameObject playerProjectileClone2;
	float t = 0;
	bool paused = false;

	//audio
    AudioSource proj_sound1;
    
    // Update is called once per frame
    void Update()
    {

		// pause detection
		if (Input.GetKeyDown ("escape")) 
		{
			paused = !paused;
			//Debug.Log ("paused = " + paused);
		}

        // projectile firing
        if (Input.GetButtonDown("Fire2"))
        {
			if (Time.time - t > .5) 
			{
				if (paused == false)
				{
				//audio
				gameObject.GetComponent<AudioSource> ().Play ();

				playerProjectileClone2 = Instantiate (playerProjectile2, transform.position, Quaternion.identity) as GameObject;
				Destroy (playerProjectileClone2, 3);
				t = Time.time;
				}
            }
        }
    }
}