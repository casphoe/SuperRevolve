using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour // 카메라가 쳐다보는 위치를 정해주는 클래스
{
    private GameObject _worldCenter; // _worldCenter라는 게임오브젝트 선언

    void Start()
    {
        _worldCenter = GameObject.FindGameObjectWithTag("WorldCenter");
    }

    void Update()
    {

        gameObject.transform.rotation = _worldCenter.transform.rotation;
    }
}