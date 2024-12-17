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
        //musicVolumeSlider.onValueChanged.AddListener(delegate { SetSlidersValue(); });
        //VFXVolumeSlider.onValueChanged.AddListener(delegate { SetSlidersValue(); });



        //slider.onValueChanged.AddListener(delegate { sliderCallBack(slider.value); });

        //GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("musicVolume");
    }

    public void SetSlidersValue()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
        Debug.Log("сохранили " + musicVolumeSlider.value.ToString());










        //PlayerPrefs.SetFloat("VFXVolume", VFXSliderValue);

        //musicVolumeSlider.value = musicSliderValue;
        //VFXVolumeSlider.value = VFXSliderValue;
        //Debug.Log(VFXSliderValue);
    }

    public void GetMusicSliderValue()
    {



        //musicVolumeSlider.value = PlayerPrefs.GetFloat( "MusicVolume",  musicVolumeSlider.value);
        float t = PlayerPrefs.GetFloat("MusicVolume", 1);
        Debug.Log("Прочитали " + t.ToString());

        musicVolumeSlider.value = t;



        //VFXSliderValue = PlayerPrefs.GetFloat("VFXVolume", VFXVolumeSlider.value);

        //musicSliderValue = musicVolumeSlider.value;
        //VFXSliderValue = VFXVolumeSlider.value;
        //Debug.Log(musicSliderValue);
    }
    private void GetVFXSliderValue()
    {
        //VFXSliderValue = PlayerPrefs.GetFloat("VFXVolume", VFXVolumeSlider.value);
        VFXSliderValue = VFXVolumeSlider.value;
        //Debug.Log(VFXSliderValue);
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