using System;
using UnityEngine.Audio; 
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameCore;

public class audiomanager : MonoBehaviour
{
    public Audio[] Audios;
    // Start is called before the first frame update
    void Awake()
    
    {
        foreach (Audio s in Audios)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop; 



        }
    }

    
    //this is example

    // Update is called once per frame
    public void play(string name)
    {
        Audio s = Array.Find(Audios, Audio => Audio.name == name);
        s.source.Play();

    }
}
