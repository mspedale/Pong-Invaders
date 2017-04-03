using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motherScript : MonoBehaviour {
    
    AudioSource scoreSound;
    public GameObject ContainmentPrefab;
    int hp=10;
    bool shield=true;
    void OnTriggerEnter2D(Collider2D other){
        
        if(shield==false){
            print(hp);
        hp=hp-1;
        if(hp<1){
            Destroy (gameObject);

        }
        }
        if(other.gameObject.tag=="Ball"){
            print("BallHit");
            shield=false;
            print(shield);
            Destroy (other.gameObject);
            StartCoroutine(shieldDelay());
        }
    }

    IEnumerator shieldDelay() {
     yield return new WaitForSeconds(5);

        shield=true;
        gameObject.GetComponent<AudioSource>().Play();
            GameObject Containment = Instantiate(ContainmentPrefab, new Vector2(0,0), Quaternion.identity);
 }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
