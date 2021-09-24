using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCheck : MonoBehaviour {
    private GameObject[] Check; //Check라는 게임오브젝트 변수

    private void Start()
    {
        Check = GameObject.FindGameObjectsWithTag("Box"); //Check가 tag를 Box로 가지는 게임오브젝트를 찾는것
        for(int i = 0; i < Check.Length; i++) //Check라는 게임오브젝트 변수의 길이만큼 돔
        {
            Check[i].GetComponent<BoxCollider>().isTrigger = true; //시작할때 통과하기 위해서 check 게임 오브젝트의 박스 콜라인더의 isTrigger 옵션을 true로 한다
        }                
    }
    private void Update()
    {
        for(int i = 0; i<Check.Length; i++)
        {
            if (this.gameObject.transform.position.y >= Check[i].transform.position.y) //플레이의 y좌표의 위치가 박스 y좌표의 위치보다 크거나 같을때
                Check[i].GetComponent<BoxCollider>().isTrigger = false; //check 게임 오브젝트의 박스콜라인더의 isTrigger의 옵션을 false로 한다 통과(x)
            else //if문이 아닐때
                Check[i].GetComponent<BoxCollider>().isTrigger = true; //통과가 가능하게한다
        }       
    }   
}
