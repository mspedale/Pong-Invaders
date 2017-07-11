using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//handles ball behavior
public class ballScript : MonoBehaviour 
{
	
	public GameObject obj_player;
	public GameObject obj_player2;

	private playerControl playerControl;
	private playerControl2 playerControl2;

	Rigidbody2D ballRigidBody;

	public float reflectionAngle;
	public float deadZone;
	private int possession = 0;			// This keeps track of which player shot/vollied last. 1 = P1, -1 = P2, 0 = neither
	private float activeZoneLeft, activeZoneRight;
	private float currentVelocity;
	

    public AudioSource colSound;
    //public AudioSource relSound;
	
	/*
	float minSpeedY = 0.5f;
	float maxSpeedY = 5f;
	float velX = 0f;
	float velY = 0f;
	//double velocity = new Vector3(velX,velY,0);
	*/
	
	void Awake ()
    {
		ballRigidBody = gameObject.GetComponent<Rigidbody2D>();
		playerControl = GetComponent<playerControl>();
		playerControl2 = GetComponent<playerControl2>();
        //relSound.Play();
		
		/*
		// Declares initial possession
		possession = (int)Mathf.Sign(ballRigidBody.velocity.y);
		print("ball: possession = " + possession);
		*/
	}
	
	void Start ()
    {
        //	velY = -minSpeedY;

        //audio, try this for implementing random sound array:
        //AudioSource[] sounds = GetComponents<AudioSource>();
        //colSound = sounds[0];
        //relSound = sounds[1];

        //if that doesn't work, try this:
        //colSound.clip = shotsound[Random.Range(o, shotsound.Length];
        //colSound.Play();
	}
	
	void Update ()
    {
		
		// update local scalar value for velocity
	    currentVelocity = Mathf.Sqrt(Mathf.Pow(ballRigidBody.velocity.x,2)+Mathf.Pow(ballRigidBody.velocity.y,2));

		// should keep ball from moving totally horiozontally (removed for now)
		/*
		var left = Vector3.Dot(ballRigidBody.velocity.normalized, Vector3.left);
		if (left > 0.98 || left < -0.98) 
		{
			Debug.Log ("Horizontal (LEFT): " +Vector3.left);
			var v = Random.insideUnitCircle * 2;
			ballRigidBody.velocity += v;
		}	

		var right = Vector3.Dot(ballRigidBody.velocity.normalized, Vector3.right);
		if (right > 0.98 || right < -0.98) 
		{
			Debug.Log ("Horizontal (RIGHT): " +Vector3.right);
			var v = Random.insideUnitCircle * 2;
			ballRigidBody.velocity += v;
		}
		*/
	}
	
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		
		//audio, plays collision sound if ball hits anything
        gameObject.GetComponent<AudioSource>().Play();
		
		
		// Collision with Projectiles
		if (coll.gameObject.tag == "Projectile_p1") 
		{
			possession = 1;
			Vector2 projForce = new Vector2(0,currentVelocity + 0.15f);
			//ballRigidBody.velocity = projForce;
			ballRigidBody.velocity += (new Vector2(transform.position.x-coll.transform.position.x,transform.position.y-coll.transform.position.y)*10f);
		}
		else if (coll.gameObject.tag == "Projectile_p2") 
		{
			possession = -1;
			ballRigidBody.velocity += (new Vector2(transform.position.x-coll.transform.position.x,transform.position.y-coll.transform.position.y)*10f);
		}		
	}
	
	
	void OnCollisionEnter2D(Collision2D coll)
    {
        //print("collisionEnter2D");

        // Imparts horizontal force using velX of paddle
        /*
		if (coll.gameObject.name == "obj_player") {
			print("player 1 collision");
			ballRigidBody.AddForce(new Vector2(coll.gameObject.GetComponent<playerControl>().velX,0));
		}
		else if (coll.gameObject.name == "obj_player2") {
			print("player 2 collision");
			ballRigidBody.AddForce(new Vector2(coll.gameObject.GetComponent<playerControl2>().velX,0));
		}
		*/

        //audio, plays collision sound if ball hits anything
        gameObject.GetComponent<AudioSource>().Play();
		
		
	
		//  Implementation ball collision with players
        if (coll.gameObject.name == "obj_player" || coll.gameObject.name == "obj_player2") 
		{
            float leftBound = coll.transform.position.x-coll.transform.lossyScale.x/2;
			float rightBound = coll.transform.position.x+coll.transform.lossyScale.x/2;
			float contactPoint = coll.contacts[0].point.x;
			float contactNormal = ((rightBound - leftBound)-(contactPoint - leftBound))/coll.transform.lossyScale.x;
			bool inDeadzone = false;
			//deadzone implementation
			float liveZone = 0.5f-deadZone/2;
			float correctedContactNormal;

			if(contactNormal > 0.5-deadZone/2 && contactNormal < 0.5+deadZone/2) 
			{
				inDeadzone = true;
			} 
			else if(contactNormal <= 0.5-deadZone/2)
			{
				correctedContactNormal = contactNormal/liveZone/2;
				contactNormal = correctedContactNormal;
			} 
			else 
			{
				correctedContactNormal = 0.5f+(contactNormal-(0.5f+deadZone/2))/liveZone/2;
				contactNormal = correctedContactNormal;
			}

			float newDirection = (180-reflectionAngle)/2 + reflectionAngle*contactNormal;
			float newDirectionRadians = newDirection * Mathf.PI/180;
			//float newX = Mathf.Cos(newDirectionRadians)*Mathf.Abs(currentVelocity);
            float newX=0;
			float newY = 0;

			if (coll.gameObject.name == "obj_player") 
			{
				newY = -Mathf.Sin (newDirectionRadians) * Mathf.Abs (currentVelocity + 0.05f);
                newX = -Mathf.Cos(newDirectionRadians)*Mathf.Abs(currentVelocity);
				possession = 1;
				print("ball: possession = " + possession);
			} 
			else if (coll.gameObject.name == "obj_player2") 
			{
				newY = Mathf.Sin (newDirectionRadians) * Mathf.Abs (currentVelocity + 0.05f);
                newX = -Mathf.Cos(newDirectionRadians)*Mathf.Abs(currentVelocity);
				possession = -1;
				print("ball: possession = " + possession);
			}

			if (!inDeadzone) 
			{
				ballRigidBody.velocity = new Vector2 (newX, newY);
			}
		}
	}

	public void SetPossession(int newPoss) 
	{
		// Little series of If statements prevents confusion between "2" and "-1", as well as keeping possession within operable range
		if (newPoss == 1)
			possession = 1;
		else if (newPoss == 0)
			possession = 0;
		else
			possession = -1;
	}
	
	public int GetPossession() {
		return possession;
	}
	
	
}
