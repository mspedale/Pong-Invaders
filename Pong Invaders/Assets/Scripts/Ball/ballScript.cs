using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour
{
    //audio
	//public AudioClip ballcollision_sound1;

	float minSpeedY = 0.5f;
	float maxSpeedY = 5f;
	float velX = 0f;
	float velY = 0f;
    //double velocity = new Vector3(velX,velY,0);


    

    void Start ()
    {
        //audio
        //GetComponent<AudioSource>().playOnAwake = false;
        //GetComponent<AudioSource>().clip = ballcollision_sound1;

        velY = -minSpeedY;
	}
	
	
	void Update ()
    {
		// Movement update
		// velocity =(velX,velY,0);
		transform.position = new Vector3(0,velY,0);
	}

    /*
    void OnCollisionEnter()  //Plays Sound Whenever collision detected
    {
        GetComponent<AudioSource>().Play();
    }
    */
}
