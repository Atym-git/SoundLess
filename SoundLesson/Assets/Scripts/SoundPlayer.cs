using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioMixer mainMixer;
    [SerializeField] private float zeroVolume;
    [Header("SoundOnEvents")]
    [SerializeField] private Slider soundVolume;
    [SerializeField] private AudioSource shootSource;
    [SerializeField] private AudioSource clashSource;
    [SerializeField] private AudioClip shootClip;
    [Header("BackGround")]
    [SerializeField] private AudioSource backgroundSource;

    private void Awake()
    {
        
    }

    private void Update()
    {
        SetSoundVolume(soundVolume.value, -80);
    }

    private void SetSoundVolume(float value, float maxVolume)
    {
        //backgroundSource.volume = slider.value;
        //audioSource.volume = slider.value;
        //Use log function to set mixer value

        //Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * (maxVolume - zeroVolume) / 4f + maxVolume;

        float volume = Mathf.Log(Mathf.Clamp(value, 0.0001f, 1f)) * (maxVolume - zeroVolume) / 4f + maxVolume;
        mainMixer.SetFloat("MasterVolume", volume);
    }

    public void PlayClashSound()
    {
        clashSource.Play();
    }

}