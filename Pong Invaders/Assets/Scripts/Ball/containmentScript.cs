using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class containmentScript : MonoBehaviour {

	int hp = 10;
	float ballForce = 500f;
	public GameObject prefab_ball;
	Rigidbody2D ballBody;

    //audio
    AudioSource hitSound;
    //AudioSource relSound;

    // Use this for initialization
    void Start ()
    {
        //AudioSource[] sounds = GetComponents<AudioSource>();
        //hitSound = sounds[0];
        //relSound = sounds[1];
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
	
	// Collision event (hopefully just with player projectiles)
	void OnTriggerEnter2D(Collider2D other)
    {
		hp -= 1;
		print(hp);

        //audio, plays if containment is hit by projectile
        gameObject.GetComponent<AudioSource>().Play();

        // HP down to 0
        if (hp < 1)
        {
            // Player One (bottom) gets last shot
            if (other.gameObject.name == "playerProjectile(Clone)")
            {
                //GameObject ball = Instantiate(prefab_ball, transform.position,Quaternion.identity) as GameObject;
                //ballBody = ball.GetComponent<Rigidbody2D>();

                prefab_ball.SetActive(true);
				prefab_ball.transform.SetParent(null);
				prefab_ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-300.0f, 300.0f),-ballForce));
				Destroy (gameObject);
			}
			
			// Player Two (top) gets last shot
			else if (other.gameObject.name == "playerProjectile2(Clone)")
            {
                //GameObject ball = Instantiate(prefab_ball, transform.position,Quaternion.identity) as GameObject;
                //ballBody = ball.GetComponent<Rigidbody2D>();
                //ballBody.AddForce(new Vector2(Random.Range(-300.0f, 300.0f),ballForce));

                prefab_ball.SetActive(true);
				prefab_ball.transform.SetParent(null);
				prefab_ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-300.0f, 300.0f),ballForce));
				Destroy (gameObject);		
			}
		}
	}
}
