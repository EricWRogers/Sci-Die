using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolume : MonoBehaviour
{

    [SerializeField] private AudioMixer masterVolume;
    [SerializeField] private AudioMixer musicVolume;
    [SerializeField] private AudioMixer sfxVolume;
    public Slider masterSlider;
    public Slider musicSlider;

    public Slider sfxSlider;

    void Update()
    {
             masterVolume.SetFloat("MasterVolume", Mathf.Log10(masterSlider.value)*20);
             musicVolume.SetFloat("MusicVolume", Mathf.Log10(musicSlider.value)*20);
             sfxVolume.SetFloat("SFXVolume", Mathf.Log10(sfxSlider.value)*20);
    }

}
