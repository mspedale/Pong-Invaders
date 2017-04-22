using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchMusicStart : MonoBehaviour
{

    static bool AudioBegin = false;
    AudioSource jeffsong1;  // MainWIP

    // Use this for initialization
    void Start()
    {

    }

    void Awake()
    {
        //audio
        AudioSource[] song = GetComponents<AudioSource>();
        jeffsong1 = song[0];

        if (!AudioBegin)
        {
            jeffsong1.Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
    }

    void Update()
    {

        if (Application.loadedLevelName == "MainMenu")
        {
            jeffsong1.Stop();
            AudioBegin = false;
        }
    }
}
