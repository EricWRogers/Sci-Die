using UnityEngine.Audio;
using System;
using UnityEngine;
using JetBrains.Annotations;
using System.Collections;
using UnityEditor;
using Unity.VisualScripting;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer musicVolume;
    public static AudioManager Instance;

    //Fade varables
    public float fadeInTime;
    public bool fadeIn;
    public bool fadeOut;
    public float time = 0f;

   

    public Sound[] sounds;
  
    private string currentlyPlaying;
    private string nextSong;

    private float musicVol;




    public void Awake()
    {
        
        //Create singleton of AudioManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);

        // Creates sources for each audio clip
        foreach (Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;
            s.audioSource.outputAudioMixerGroup = s.AudioGroup;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.loop;
            s.audioSource.playOnAwake = s.playOnAwake;

        }
    }

     void Update()
    {
                
             
   
        if (fadeOut)
        {  
            time += Time.deltaTime;
            musicVol = Mathf.Lerp(1f, 0.0001f, time/fadeInTime); 
            musicVolume.SetFloat("MusicVolume", Mathf.Log10(musicVol )* 20f); // math to adjust for mixer falloff on volume

        }
        if (fadeIn) {
                time += Time.deltaTime;
                musicVol = Mathf.Lerp(0.0001f, 1f, time/fadeInTime);
                musicVolume.SetFloat("MusicVolume", Mathf.Log10(musicVol)* 20f); // math to adjust for mixer falloff on volume
        }


    }
    // Plays the sound you called and named
    public void PlaySound(string name){
        Sound s =  Array.Find(sounds, s => s.name == name);
            time = 0f;
        s.audioSource.Play();
    }

    public void PlayMusic(string name)
    {
        if (name != currentlyPlaying){
            time = 0f;

            if (currentlyPlaying == null)
            {
                Sound s = Array.Find(sounds, s => s.name == name);
                currentlyPlaying = name;
    
                s.audioSource.Play();
            }
            else
            {
                fadeOut = true;
                Invoke(nameof(FadeOut), fadeInTime);
           
                nextSong = name;
            }
        }

    } 
    void FadeIn()
    {
        fadeIn = false;
        time = 0f;
    }

    void FadeOut()
    {
        
        Sound s = Array.Find(sounds, s => s.name == currentlyPlaying);// finds current song audiosorce
        s.audioSource.Stop();
        fadeOut = false;

        Sound a = Array.Find(sounds, s => s.name == nextSong); // finds the next song audiosorce
        a.audioSource.Play();

        time = 0f;
        fadeIn = true;
        Invoke(nameof(FadeIn), fadeInTime);
        currentlyPlaying = nextSong;
        
    }

}
