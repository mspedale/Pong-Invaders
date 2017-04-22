using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//handles mothership behavior.
//mothership has a shield that is disabled by the ball,
//and health that is lowered by damage from fighter ship weapons.
//once the mothership health reaches zero, the ship is destroyed and the round ends.


public class motherScript : MonoBehaviour 
{
	
    //audio
    AudioSource shielddisable;
    AudioSource shiphit;
    AudioSource shieldenable;
    //AudioSource shipdestroyed;


    public GameObject shieldObj;
    int healthBarLength;
    public GameObject ContainmentPrefab;
    int hp=10;
    bool shield=true;
    GameObject shieldclone;
    Vector3 position = new Vector3(0f,-10.18f,0f);
    
     public Texture2D bgImage; 
     public Texture2D fgImage; 

    void OnTriggerEnter2D(Collider2D other)
	{
    
        //handles HP if shield is down
        if(shield==false)
		{
            print(hp);
        	hp=hp-1;
            shiphit.Play();
        
			if(hp<1)
			{
				Application.LoadLevel("P2Win");
            	//Destroy (gameObject);
			}
        }

		//handles shield if ball hits mothership
        if(other.gameObject.tag=="Ball")
		{
            print("BallHit");
            shield=false;
            shieldclone.SetActive(false);
            //Destroy(shieldclone);
            print(shield);
            Destroy (other.gameObject);
            StartCoroutine(shieldDelay());
            shielddisable.Play();
        }
    }

	//regens shield over time
    IEnumerator shieldDelay() 
	{
		
        yield return new WaitForSeconds(5);
        shield=true;
        shieldclone.SetActive(true);
        //GameObject shieldclone = Instantiate(shieldObj, position, Quaternion.identity) as GameObject;
        GameObject Containment = Instantiate(ContainmentPrefab, new Vector2(0,0), Quaternion.identity);
        shieldenable.Play();
 	}

	// Use this for initialization
	void Start () 
	{
        //healthBarLength = Screen.width /2;    
        shieldclone  = Instantiate(shieldObj, position ,Quaternion.identity) as GameObject;

        //audio
        AudioSource[] audio = GetComponents<AudioSource>();
        shielddisable = audio[0];
        shiphit = audio[1];
        shieldenable = audio[2];
        //shipdestroyed = audio[3];
    }
	
	// Update is called once per frame
	void Update () 
	{
		//healthBarLength =(Screen.width /2) * (hp / 10);
	}
  /*  void OnGUI () {
         // Create one Group to contain both images
         // Adjust the first 2 coordinates to place it somewhere else on-screen
         GUI.BeginGroup (new Rect (0,550, healthBarLength,32));
 
         // Draw the background image
         GUI.Box (new Rect (0,0, healthBarLength,32), bgImage);
 
         // Create a second Group which will be clipped
         // We want to clip the image and not scale it, which is why we need the second Group
         GUI.BeginGroup (new Rect (0,0, hp / 10 * healthBarLength, 32));
 
         // Draw the foreground image
         GUI.Box (new Rect (0,0,healthBarLength,32), fgImage);
 
         // End both Groups
         GUI.EndGroup ();
 
         GUI.EndGroup ();
    }
    */
}
