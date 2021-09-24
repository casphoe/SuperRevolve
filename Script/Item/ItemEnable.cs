using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEnable : MonoBehaviour {

    private CameraRotator Rotator;

    private void Start()
    {
        Rotator = FindObjectOfType<CameraRotator>();
        this.GetComponent<BoxCollider>().enabled = true;
    }
    // Update is called once per frame
    private void Update () {
        
        if (Rotator.turn == true)
        {
            this.GetComponent<BoxCollider>().enabled = false;
        }
        else
            this.GetComponent<BoxCollider>().enabled = true;
            
    }

}
