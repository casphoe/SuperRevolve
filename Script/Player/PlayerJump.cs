using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public bool Ground = false; //플레이어가 땅에 있는지 확인하는 bool형

    private bool Jump; //플레이어의 점프상태를 나타냄
    private float JumpPower = 450f; //점프 속도를 결정하는 변수
    private Rigidbody theRigid;
    private int JumpCount; //점프 카운트
    void Start()
    {
        //JumpCount = 1; //1번만 점프를 가능하게 해주기 위해서
        theRigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckGround(); //밑이 땅인지 체크
        if (!Ground && JumpCount == 1)
        {
            Jump = true;
        }
        if (Input.GetKeyDown(KeyCode.C) && !Jump && JumpCount > 0)
        {
            theRigid.AddForce(new Vector3(0f, JumpPower, 0f));
            Jump = false;
            JumpCount = 0;
        }
    }

    public void JumpCheck() //점프 관련 물리 움직임을 처리
    {
        if (!Jump && JumpCount > 0)
        {
            theRigid.AddForce(new Vector3(0f, JumpPower, 0f));
            Jump = false;
            JumpCount = 0;

            GameObject.Find("Jump").GetComponent<AudioSource>().Play();

        }
    }

    void CheckGround() //캐릭터가 땅에 있는지 체크하는 함수
    {
        RaycastHit hit;
        //Debug.DrawRay(transform.position, Vector3.down * 0.6f, Color.red); //캐릭터 위치의 0.554f길이 만큼 밑의 빨간색 색깔의 선을 그림

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.6f))
        //Physics.Raycast : 레이캐스트와 오브젝트의 충돌을 처리
        {
            if (hit.transform.tag == "Platform" || hit.transform.tag == "Box" || hit.transform.tag == "NormalPlatform") //부딪친 위치의 tag가 Ground일때 와 부딪친 위치의 tag가 Box일때 땅으로 판단
            {
                Ground = true; //땅이 있음
                JumpCount = 1; //점프 카운트를 다시 1로 되돌림
                Jump = false; //점프를 false상태로 되돌림
                return;
            }
        }
        Ground = false;
    }

}
