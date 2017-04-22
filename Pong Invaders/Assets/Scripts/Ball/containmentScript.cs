using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//handles ball container behavior
public class containmentScript : MonoBehaviour 
{

	int maxHP;
	int hp;
	float ballForce = 500f;
    bool paused = false;
	
	public GameObject prefab_ball;
    public GameObject invader;

    Rigidbody2D ballBody;
	Rigidbody2D containment;
	
	// Oscillation variables
	float amp =  6.5f;		                        // Amplitude of displacement
	float freq = 0f;	                            // Frequency of oscillation  (increases with every shot fired)
	float t = 0f;		                	        // Time since oscillation began (in frames)
	float x = 0f; 		                            // Current x position
	float prevX = 0f;	                            // Previous x position
	Vector3 newPosition = new Vector3 (0f,0f,0f);	// Need a Vector3 for use with MovePosition()
	int direction = 1;	                            // Indicates whether the containment is going right or left. Crucial for maintaining direction when frequency changes.
	// Make this ^^^^ -1 or 1 randomly!

	
    //audio
    AudioSource hitSound;
    //AudioSource relSound;

    // Use this for initialization
    void Start ()
    {
		//tentative array-based sound implementation, may be unneccessary
        //AudioSource[] sounds = GetComponents<AudioSource>();
        //hitSound = sounds[0];
        //relSound = sounds[1];

		//initalize containment HP
		maxHP = 5; //rand.Next(6,12); (testing health)
		hp = maxHP;
		containment = gameObject.GetComponent<Rigidbody2D>();

        Instantiate(invader, new Vector2(0, 3), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update ()
    {
		// pause detection
		if (Input.GetKeyDown ("escape")) 
		{
			paused = !paused;
			//Debug.Log ("paused = " + paused);
		}
			

		//Movement oscillation based on HP
		if(hp < maxHP) 
		{
			// handles pausing the container properly
			if (paused == false) 
			{
				t += 1 * direction;
				prevX = x;
				x = amp * Mathf.Sin (2 * Mathf.PI * freq * t);
				newPosition.x = x;
				containment.MovePosition (newPosition);
			}
		}
	}
	
	// Collision event (hopefully just with player projectiles)
	void OnTriggerEnter2D(Collider2D other)
    {	
		// HP modification
		hp -= 1;
		print(hp); //testing
		
		// Frequency modification
		freq += 0.001f;
		if (x-prevX >= 0) 
		{
			print("going right");
			t = (Mathf.Asin(x/amp) + (2* Mathf.PI)) / (2*Mathf.PI*freq);	// offsets t so x won't make a crazy jump when frequency changes
			direction = 1;
		}
		else 
		{
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
                prefab_ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-150.0f, 150.0f), ballForce));
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
				prefab_ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-150.0f, 150.0f),-ballForce));
				Destroy (gameObject);		
			}
		}
	}
}
