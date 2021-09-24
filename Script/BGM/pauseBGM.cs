using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseBGM : MonoBehaviour {

    private bool pause;
    private GameObject Op;

    public void op()
    {
        Op = GameObject.Find("Canvas").transform.Find("BGM").gameObject;

        if (pause==false)
        {
            Op.gameObject.SetActive(true);

        }
        else if(pause==true)
        {
            Op.gameObject.SetActive(false);

        }
        pause = !pause;
    }

}
