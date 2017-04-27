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
    public GameObject ContainmentPrefab;
    public GameObject healthBar;
	public GameObject blueDroneFleet;
	
	public Vector2 fleetPosition = new Vector2(0f,-10f);
	
    int eng =0;
    int hp=10;
    bool shield=true;
    GameObject shieldclone;
    //Vector3 position = new Vector3(0f,0f,0f);	// original values:  (0f,-10.18f,0f);

    void OnTriggerEnter2D(Collider2D other)
	{
        if(other.gameObject.name == "energy(Clone)")
        {
			eng++;
			Destroy(other.gameObject);
			print("energy:" + eng);
        }
        //handles HP if shield is down
        if(shield==false && other.gameObject.name!="energy")
		{
            print(hp);
        	hp=hp-1;
            decreaseHealth();
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
            shieldObj.SetActive(false);
            Destroy (other.gameObject);
            StartCoroutine(shieldDelay());
            shielddisable.Play();
        }
    }

    /*
    void OnGUI()   for text HP display
    {
        GUI.Label(new Rect(Screen.width - 500, Screen.height - 50, Screen.width, Screen.height), "TEST TEST TEST");
    }
    */

    // method that decreases HP on hit for the health bar
    protected void decreaseHealth()
    {
        float calc_health = hp / 10f;
        setHealthBar(calc_health);
    }

    // changes the size of the HP bar
    public void setHealthBar(float myHealth)
    {
        healthBar.transform.localScale = new Vector3(myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        healthBar.transform.position = new Vector3(healthBar.transform.position.x - 0.15f, healthBar.transform.position.y, healthBar.transform.position.z);
    }

    //regens shield over time
    IEnumerator shieldDelay() 
	{
		
        yield return new WaitForSeconds(5);
        shield=true;
        shieldObj.SetActive(true);
        //GameObject shieldObj = Instantiate(shieldObj, position, Quaternion.identity) as GameObject;
        GameObject Containment = Instantiate(ContainmentPrefab, new Vector2(0,0), Quaternion.identity);
        shieldenable.Play();
 	}

	// Use this for initialization
	void Start () 
	{
        shield = true;
		shieldObj.SetActive(true);
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
		// Drone Fleet Spawn
		if(eng>=10){
			Instantiate(blueDroneFleet, fleetPosition, Quaternion.identity);
            eng -= 10;
        }

		// Shield regenration
		if (shield && !shieldObj.activeSelf) {	// Compares local var "shield" with shieldObj's active status.  Yields true if the shield was deactivated on this frame.
			shield = false;
			StartCoroutine(shieldDelay());
            shielddisable.Play();
		}
	}
}
