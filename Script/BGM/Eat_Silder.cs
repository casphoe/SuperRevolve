using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eat_Silder : MonoBehaviour {

    public Slider backVolume;
    static AudioSource audio;
    private float EatVol = 1f;



    void Start()
    {
        audio = GameObject.Find("apple").GetComponent<AudioSource>();
        EatVol = PlayerPrefs.GetFloat("Eat", 1f);
        backVolume.value = EatVol;
        audio.volume = backVolume.value;
        //PlayerPrefs.DeleteAll();
    }

    void Update()
    {
        SoundSlider();
    }

    public void SoundSlider()
    {
        audio.volume = backVolume.value;

        EatVol = backVolume.value;
        PlayerPrefs.SetFloat("Eat", EatVol);
    }
}
