using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr1 : MonoBehaviour
{
    private Button button;

    [SerializeField] private Slider slider;

    void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(SetSliderValue);
    }
    private void SetSliderValue()
    {
        //slider.value = 1;
        float t = PlayerPrefs.GetFloat("MusicVolume", 1);
        Debug.Log(t.ToString());

        slider.value = t;

    }
}
