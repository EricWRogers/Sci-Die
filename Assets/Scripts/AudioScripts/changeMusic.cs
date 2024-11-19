using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMusic : MonoBehaviour
{

    public string musicName;

    public GameObject audioObject;

     public AudioManager audioManager;


    void Awake(){
        audioObject = GameObject.Find("AudioManager");
        audioManager = audioObject.GetComponent<AudioManager>();
    }

    public void OnTriggerEnter2D(){
        audioManager.PlayMusic(musicName);
    }
}
