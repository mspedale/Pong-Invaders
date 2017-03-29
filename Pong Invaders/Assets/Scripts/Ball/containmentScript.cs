using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class containmentScript : MonoBehaviour {

	//Random rand = new Random();
	int maxHP;
	int hp;
	float ballForce = 500f;
	public GameObject prefab_ball;
	Rigidbody2D ballBody;
	Rigidbody2D containment;
	
	// Oscillation variables
	float amp =  6.5f;		// Amplitude of displacement
	float freq = 0f;	// Frequency of oscillation  (increases with every shot fired)
	float t = 0f;			// Time since oscillation began (in frames)
	int startTime;		// Time that oscillation began
	float x = 0f; 		// Current x position
	float prevX = 0f;	// Previous x position
	Vector3 newPosition = new Vector3 (0f,0f,0f);	// Need a Vector3 for use with MovePosition()
	Vector2 newVelocity = new Vector2 (0f,0f);
	int direction = 1;
	
    //audio
    AudioSource hitSound;
    //AudioSource relSound;

    // Use this for initialization
    void Start ()
    {
        //AudioSource[] sounds = GetComponents<AudioSource>();
        //hitSound = sounds[0];
        //relSound = sounds[1];
		
		maxHP = 10;//rand.Next(6,12);
		hp = maxHP;
		containment = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		//Oscillation
		if(hp < maxHP) {
			t += 1 * direction;
			prevX = x;
			x = amp * Mathf.Sin(2 * Mathf.PI * freq * t);
			newPosition.x = x;
			containment.MovePosition(newPosition);
			/*
			newVelocity.x = x - prevX;
			containment.velocity = newVelocity;
			*/
		}
	}
	
	// Collision event (hopefully just with player projectiles)
	void OnTriggerEnter2D(Collider2D other)
    {
		/*
		// set startTime if this is the first shot
		if (hp == maxHP) {
			startTime = Time.frameCount;}
		*/
		
		// HP modification
		hp -= 1;
		print(hp);
		
		// Frequency modification
		freq += 0.001f;
		if (x-prevX >= 0) {
			print("going right");
			t = (Mathf.Asin(x/amp) + (2* Mathf.PI)) / (2*Mathf.PI*freq);	// offsets t so x won't make a crazy jump when frequency changes
			direction = 1;
		}
		else {
			print("going left");
			t = ((Mathf.Asin(x/amp) + (2* Mathf.PI)) / (2*Mathf.PI*freq));
			direction = -1;
		}
		
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
				prefab_ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-150.0f, 150.0f),-ballForce));
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
				prefab_ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-150.0f, 150.0f),ballForce));
				Destroy (gameObject);		
			}
		}
	}
}
