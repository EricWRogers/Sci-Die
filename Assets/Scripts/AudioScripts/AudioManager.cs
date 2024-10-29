using UnityEngine.Audio;
using System;
using UnityEngine;
using JetBrains.Annotations;
using System.Collections;
using UnityEditor;
using Unity.VisualScripting;

public class AudioManager : MonoBehaviour
{
    public float fadeInTime = 3f;
    public bool fadeIn;
    public bool fadeOut;
    public Sound[] sounds;
    public static AudioManager Instance;
    private string currentlyPlaying;
    private string nextSong;
    [SerializeField] private AudioMixer musicVolume;

    public float delayTime = 0f;
    public float time = 0f;


    public void Awake()
    {
        
        //Keeps AudioMangaer between Scenes
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
                
             
            float musicVol = 0f;
     
        if (fadeOut)
        {  
            time += Time.deltaTime;
            musicVol = Mathf.Lerp(1f, 0.01f, time/fadeInTime);
            musicVolume.SetFloat("MusicVolume", Mathf.Log10(musicVol )* 20f);
            Debug.Log(musicVol.ToString());
            
    
            
        }
        if (fadeIn )
        {
        

              
                time += Time.deltaTime;
                musicVol = Mathf.Lerp(0.01f, 1f, time/fadeInTime);
                musicVolume.SetFloat("MusicVolume", Mathf.Log10(musicVol)* 20f);
                
              
            
      

        }


    }
    // Plays the sound you called and named
    public void PlaySound(string name)
    {
        Sound s =  Array.Find(sounds, s => s.name == name);
            time = 0f;
        s.audioSource.Play();

       
    }

    public void PlayMusic(string name)
    {
    
        
        if (name != currentlyPlaying)
        {
        
            if (currentlyPlaying == null)
            {
                Sound s = Array.Find(sounds, s => s.name == name);
                currentlyPlaying = name;
    
                s.audioSource.Play();

              
            }
            else
            {
                
                //Sound s = Array.Find(sounds, s => s.name == currentlyPlaying);

                fadeOut = true;
                Invoke(nameof(FadeOut), fadeInTime);
                //s.audioSource.Stop();
                nextSong = name;

               
                //Sound a = Array.Find(sounds, s => s.name == name);
                //currentlyPlaying = name;

                
                 //a.audioSource.Play();
                //fadeIn = true;
                //Invoke(nameof(FadeIn), fadeInTime);

                


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
        Sound s = Array.Find(sounds, s => s.name == currentlyPlaying);
        s.audioSource.Stop();
        fadeOut = false;
        Sound a = Array.Find(sounds, s => s.name == nextSong);
        a.audioSource.Play();
        fadeIn = true;
        Invoke(nameof(FadeIn), fadeInTime);
        time = 0f;
        
       currentlyPlaying = nextSong;
        
    }

}
