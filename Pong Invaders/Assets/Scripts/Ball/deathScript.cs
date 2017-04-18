using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//handles death behavior for container
public class deathScript : MonoBehaviour
{

    AudioSource scoreSound;
    public GameObject ContainmentPrefab;

	void Start()
    {
		
	}
	
	// Update is called once per frame
	void Update()
    {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "prefab_ball")
        {
            gameObject.GetComponent<AudioSource>().Play();
            Destroy (other.gameObject);
            GameObject Containment = Instantiate(ContainmentPrefab, new Vector2(0,0), Quaternion.identity);
		}
    }
}