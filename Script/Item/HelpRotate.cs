using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpRotate : MonoBehaviour
{

    private CameraRotator Rotator;

    private void Start()
    {
        Rotator = FindObjectOfType<CameraRotator>();
    }
    // Update is called once per frame
    private void Update()
    {
        HelpRotation();
    }

    private void HelpRotation()
    {
        if (Rotator.RotationAngle == 180 && (this.transform.rotation.eulerAngles.y != 180))
        {
            this.transform.Rotate(new Vector3(0, 180, 0));
        }
        if (Rotator.RotationAngle == 0 && (this.transform.rotation.eulerAngles.y == 180))
        {
            this.transform.Rotate(new Vector3(0, -180, 0));
        }
    }

}
