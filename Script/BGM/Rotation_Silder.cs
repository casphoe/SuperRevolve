using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation_Silder : MonoBehaviour {

    public Slider backVolume;
    static AudioSource audio;
    private float RotationVol = 1f;



    void Start()
    {
        audio = GameObject.Find("rotation").GetComponent<AudioSource>();
        RotationVol = PlayerPrefs.GetFloat("Rotation", 1f);
        backVolume.value = RotationVol;
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

        RotationVol = backVolume.value;
        PlayerPrefs.SetFloat("Rotation", RotationVol);
    }
}
