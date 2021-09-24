using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Die_Silder : MonoBehaviour {

    public Slider backVolume;
    static AudioSource audio;
    private float DieVol = 1f;

    

    void Start()
    {
        audio = GameObject.Find("die").GetComponent<AudioSource>();
        DieVol = PlayerPrefs.GetFloat("Die", 1f);
        backVolume.value = DieVol;
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

        DieVol = backVolume.value;
        PlayerPrefs.SetFloat("Die", DieVol);
    }
}
