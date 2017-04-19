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
    AudioSource scoreSound;
    public GameObject shieldObj;
    public GameObject ContainmentPrefab;
    int hp=10;
    bool shield=true;
    GameObject shieldclone;
    Vector3 position = new Vector3(0f,-10.18f,0f);
    void OnTriggerEnter2D(Collider2D other)
	{
    
        //handles HP if shield is down
        if(shield==false)
		{
            print(hp);
        	hp=hp-1;
        
			if(hp<1)
			{
            Destroy (gameObject);
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
        }
    }

	//regens shield over time
    IEnumerator shieldDelay() 
	{
		
     yield return new WaitForSeconds(5);
     shield=true;
     shieldclone.SetActive(true);
     //GameObject shieldclone = Instantiate(shieldObj, position, Quaternion.identity) as GameObject;
     gameObject.GetComponent<AudioSource>().Play();
     GameObject Containment = Instantiate(ContainmentPrefab, new Vector2(0,0), Quaternion.identity);
 	}

	// Use this for initialization
	void Start () 
	{
     shieldclone  = Instantiate(shieldObj, position ,Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
