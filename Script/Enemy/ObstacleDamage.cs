using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDamage : MonoBehaviour {

    public Rigidbody Rigid;

    private GameObject Player;
    private float MoveSpeed = 20f;
    private CameraRotator CamerRotation;
    private PlayerStat playStat;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); //Player들의 게임오브젝트의 tag를 찾음
        CamerRotation = FindObjectOfType<CameraRotator>();
        playStat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStat>(); //플레이어 스텟의 스크립트를 받기 위해서 Player이라는 태그를 찾고 그 플레이어의 태그의 플레이어스텟이라는 스크립트를 받아옴
    }

    private void OnTriggerEnter(Collider collision) //여기서는 hp랑 하트 이미지를 변화시켜줌 (한번만 충돌되게)
    {
        if (collision.gameObject.tag == "Player") //장애물의 이름을 가진 tag에 달았을때 플레이어가 팅겨나감
        {
            playStat.currentHp -= 0.5f; //부딪칠때 마다 0.5만큼 빼버림
            HeartUI.Instance.TakeDamage(1); //부딪칠때마다 Heart 이미지 값이 변화 
        }
    }

    private void OnTriggerStay(Collider other) //(충돌되는동안 계속발생) 충돌이 되면 플레이어가 팅겨나가게 되는 작용
    {
        if(other.gameObject.tag == "Player") //장애물의 이름을 가진 tag에 달았을때 플레이어가 팅겨나감
        {
            //GameObject.Find("shot").GetComponent<AudioSource>().Play();

            if (CamerRotation.turn == false) //회전이 않되었을때 x값이 이동
            {
                if (this.gameObject.transform.position.x < Player.gameObject.transform.position.x)
                {
                    Rigid.AddForce(new Vector3(MoveSpeed, MoveSpeed, 0f));
                }
                else
                {
                    Rigid.AddForce(new Vector3(-MoveSpeed, MoveSpeed, 0f));
                }
            }
            if (CamerRotation.turn == true) //회전이 되면 캐릭터가 z값으로 이동하므로 z값이 변화
            {
                if (this.gameObject.transform.position.z < Player.gameObject.transform.position.z)
                {
                    Rigid.AddForce(new Vector3(0f, MoveSpeed, MoveSpeed));
                }
                else
                {
                    Rigid.AddForce(new Vector3(0f, MoveSpeed, -MoveSpeed));
                }
            }
        }
    }
}
