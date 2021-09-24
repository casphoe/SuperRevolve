using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clear_Silder : MonoBehaviour {

    public Slider backVolume;
    static AudioSource audio;
    private float ClearVol = 1f;



    void Start()
    {
        audio = GameObject.Find("clear").GetComponent<AudioSource>();
        ClearVol = PlayerPrefs.GetFloat("Clear", 1f);
        backVolume.value = ClearVol;
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

        ClearVol = backVolume.value;
        PlayerPrefs.SetFloat("Clear", ClearVol);
    }
}
