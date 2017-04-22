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
    int hp=10;
    bool shield=true;
    GameObject shieldclone;
    Vector3 position = new Vector3(0f,10.18f,0f);
    void OnTriggerEnter2D(Collider2D other)
	{
        //handles HP if shield is down
        if(shield==false)
		{
            print(hp);
        	hp=hp-1;
            shiphit.Play();

            if (hp<1)
			{
                Destroy (gameObject);
			}
        }

		//handles shield if ball hits mothership
        if(other.gameObject.tag=="Ball")
		{
            print("BallHit");
            shield=false;
            //Destroy(shieldclone);
            shieldclone.SetActive(false);
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
        //GameObject shieldclone = Instantiate(shieldObj, position, Quaternion.identity) as GameObject;
        shieldclone.SetActive(true);
        gameObject.GetComponent<AudioSource>().Play();
	    GameObject Containment = Instantiate(ContainmentPrefab, new Vector2(0,0), Quaternion.identity);
        shieldenable.Play();
    }

	// Use this for initialization
	void Start () 
	{
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
		
	}
}
