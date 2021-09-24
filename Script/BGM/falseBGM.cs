using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falseBGM : MonoBehaviour {

    //private bool pause = false;
    private GameObject Op;

    public void op()
    {
        Op = GameObject.Find("Canvas").transform.Find("BGM").gameObject;

        if (Op==true)
        {
            Op.gameObject.SetActive(!true);

        }
       else if(Op==false)
        {
            Op.gameObject.SetActive(true);
        }
    }

}
