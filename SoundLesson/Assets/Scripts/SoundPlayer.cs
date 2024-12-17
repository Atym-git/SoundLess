using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioMixer mainMixer;
    [SerializeField] private float zeroVolume;
    [SerializeField] private float maxVolume;
    [SerializeField] private Slider musicVolumeSlider;
    private float musicSliderValue;
    [SerializeField] private Slider VFXVolumeSlider;
    private float VFXSliderValue;
    [SerializeField] private AudioSource clashSource;

    public void SetSlidersValue()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
    }

    public void GetMusicSliderValue()
    {
        float t = PlayerPrefs.GetFloat("MusicVolume", 1);

        musicVolumeSlider.value = t;
    }

    private void Update()
    {       
        SetMusicVolume(musicVolumeSlider.value, VFXVolumeSlider.value);
        SetVFXVolume(VFXVolumeSlider.value, maxVolume);
    }

    private void SetMusicVolume(float musicValue, float VFXValue)
    {
        float volume = Mathf.Log(Mathf.Clamp(musicValue, 0.0001f, 1f)) * (maxVolume - zeroVolume) / 4f + maxVolume;
        mainMixer.SetFloat("MusicVolume", volume);
    }
    private void SetVFXVolume(float value, float maxVolume)
    {
        float volume = Mathf.Log(Mathf.Clamp(value, 0.0001f, 1f)) * (maxVolume - zeroVolume) / 4f + maxVolume;
        mainMixer.SetFloat("VFXVolume", volume);
    }

    public void PlayClashSound()
    {
        clashSource.Play();
    }

    public void AddDistortion()
    {
        mainMixer.SetFloat("Level(MusicDistortion)", 0.75f);
        StartCoroutine(Delay());
        mainMixer.SetFloat("Level(MusicDistortion)", 0f);
    }

    public void SetValueAfterLoss(float value)
    {
        mainMixer.SetFloat("MasterVolume", value);
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(10f);
    }
}