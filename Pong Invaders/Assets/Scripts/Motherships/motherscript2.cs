using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//handles mothership behavior.
//mothership has a shield that is disabled by the ball,
//and health that is lowered by damage from fighter ship weapons.
//once the mothership health reaches zero, the ship is destroyed and the round ends.
public class motherscript2 : MonoBehaviour
{

    //audio
    AudioSource shielddisable;
    AudioSource shiphit;
    AudioSource shieldenable;
    //AudioSource shipdestroyed;

    public GameObject shieldObj;
    public GameObject ContainmentPrefab;
    public GameObject healthBar;
	public GameObject redDroneFleet;
	
	public Vector2 fleetPosition = new Vector2(0f,10f);
	
    int eng=0;
    int hp=10;
    bool shield=true;
    //GameObject shieldclone;
    Vector3 position = new Vector3(0f,10.18f,0f);

    void OnTriggerEnter2D(Collider2D other)
	{
        //handles HP if shield is down
        if(other.gameObject.name=="energy2(Clone)"){
            eng++;
            Destroy(other.gameObject);
        }
        if(shield==false)
		{
            print(hp);
        	hp=hp-1;
            decreaseHealth();
            shiphit.Play();

            if (hp<1)
			{
                Application.LoadLevel("P1Win");
                //Destroy (gameObject);
            }
        }

		//handles shield if ball hits mothership
        if(other.gameObject.tag=="Ball")
		{
            print("BallHit");
            shield=false;
			shieldObj.SetActive(false);		//shieldclone.SetActive(false);
            print(shield);
            Destroy (other.gameObject);
            StartCoroutine(shieldDelay());
            shielddisable.Play();
        }
    }

    // method that decreases HP on hit for the health bar
    protected void decreaseHealth()
    {
        float calc_Health = hp / 10f;
        setHealthBar(calc_Health);
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
	    GameObject Containment = Instantiate(ContainmentPrefab, new Vector2(0,0), Quaternion.identity);
        shieldenable.Play();
    }

	// Use this for initialization
	void Start () 
	{
        //shieldclone  = Instantiate(shieldObj, position ,Quaternion.identity) as GameObject;
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
			Instantiate(redDroneFleet, fleetPosition, Quaternion.identity);
            eng -= 10;
        }
		
		// Shield regenration -- (added by Cam 4/27)
		if (shield && !shieldObj.activeSelf) {	// Compares local var "shield" with shieldObj's "active" status.  Yields true if the shield was deactivated on this frame.
			shield = false;
			StartCoroutine(shieldDelay());
            shielddisable.Play();
		}
	}
}
