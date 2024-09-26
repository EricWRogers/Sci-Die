using UnityEngine.Audio;
using System;
using UnityEngine;
using JetBrains.Annotations;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager Instance;


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

            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.loop;

        }
    }
    // Plays the sound you called and named
    public void PlaySound(string name)
    {
        Sound s =  Array.Find(sounds, s => s.name == name);

        s.audioSource.Play();
    }
}
