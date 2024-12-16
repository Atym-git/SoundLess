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

    private void Start()
    {
        musicVolumeSlider.onValueChanged.AddListener(delegate { GetMusicSliderValue(); });
        VFXVolumeSlider.onValueChanged.AddListener(delegate { GetVFXSliderValue(); });

        //slider.onValueChanged.AddListener(delegate { sliderCallBack(slider.value); });

        //GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("musicVolume");
    }


    public void SetSlidersValue()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSliderValue);
        PlayerPrefs.SetFloat("VFXVolume", VFXSliderValue);
        Debug.Log(musicVolumeSlider.value);
        Debug.Log(VFXVolumeSlider.value);
    }

    private void GetMusicSliderValue()
    {
        //musicSliderValue = PlayerPrefs.GetFloat("MusicVolume", musicVolumeSlider.value);
        musicSliderValue = musicVolumeSlider.value;
        Debug.Log(musicSliderValue);
    }
    private void GetVFXSliderValue()
    {
        //VFXSliderValue = PlayerPrefs.GetFloat("VFXVolume", VFXVolumeSlider.value);
        VFXSliderValue = VFXVolumeSlider.value;
        Debug.Log(VFXSliderValue);
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
        //Debug.Log("AddDistortion");
        mainMixer.SetFloat("Level(MusicDistortion)", 0.75f);
        //Debug.Log("MusicDist");
        StartCoroutine(Delay());
        mainMixer.SetFloat("Level(MusicDistortion)", 0f);
        //Debug.Log("MusicDist");
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