using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Language : MonoBehaviour {



    //0 한국어
    //1 영어

    public static int i = 0;
    public void speak()
    {
        if (i == 0)
        {
            i = 1;
        }

        else if (i == 1)
        {
            i = 0;
        }

        Debug.Log(i);
    }
}
