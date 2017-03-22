using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript2 : MonoBehaviour
{

    public GameObject playerProjectile2;
    GameObject playerProjectileClone2;
    //audio
    AudioSource proj_sound1;
    float t = 0;

    // Update is called once per frame
    void Update()
    {
        // projectile firing
        if (Input.GetButtonDown("Fire2"))
        {
            if (Time.time - t > .5)
            {
                playerProjectileClone2 = Instantiate(playerProjectile2, transform.position, Quaternion.identity) as GameObject;
                //audio
                gameObject.GetComponent<AudioSource>().Play();
                Destroy(playerProjectileClone2, 3);
                t = Time.time;
            }
        }
    }
}