using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jump_Silder : MonoBehaviour {

    public Slider backVolume;
    static AudioSource audio;
    private float JumpVol = 1f;



    void Start()
    {
        audio = GameObject.Find("Jump").GetComponent<AudioSource>();
        JumpVol = PlayerPrefs.GetFloat("Jump", 1f);
        backVolume.value = JumpVol;
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

        JumpVol = backVolume.value;
        PlayerPrefs.SetFloat("Jump", JumpVol);
    }
}
