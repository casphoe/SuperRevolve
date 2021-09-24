using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shot_Silder : MonoBehaviour {

    public Slider backVolume;
    static AudioSource audio;
    private float ShotVol = 1f;



    void Start()
    {
        audio = GameObject.Find("shot").GetComponent<AudioSource>();
        ShotVol = PlayerPrefs.GetFloat("Shot", 1f);
        backVolume.value = ShotVol;
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

        ShotVol = backVolume.value;
        PlayerPrefs.SetFloat("Shot", ShotVol);
    }
}
