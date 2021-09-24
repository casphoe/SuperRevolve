using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpen : MonoBehaviour
{
    private UIManager UI;
    private StarUI TheStar;
    private SaveNLoad TheSaveNLoad;
    private StageManager Stage;

    private void Start()
    {
        
    }

    //public FadeContriller theFade;
    private void OnTriggerEnter(Collider other) //충돌처리
    {
        UI = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        TheStar = FindObjectOfType<StarUI>();
        TheSaveNLoad = FindObjectOfType<SaveNLoad>(); //SaveNLoad의 스크립트를 찾음
        Stage = FindObjectOfType<StageManager>();
        if (other.gameObject.tag == "Player") //플레이어의 충돌이 되었을때 -> 씬을 넘김(이 게임씬을 클리어) -> 다음 스테이지로 전환
        {
            UI.ClearPanel.gameObject.SetActive(true);
            TheStar.ChangeStarImage();
            if(SaveData.ThisStage >= SaveData.FinalStage)
            {
                if(SaveData.FinalStage < 8)
                {
                    SaveData.FinalStage++;
                }
                //SaveData.FinalStage = SaveData.ThisStage;
            }
            //TheSaveNLoad.Save(); //스테이지 데이터 저장(Save 함수 실행)
            Time.timeScale = 0f; //게임 일시정지            
                                 //StartCoroutine(AddScene(1)); //AddScene의 코루틴을 한번만 실행
            GameObject.Find("clear").GetComponent<AudioSource>().Play();
        }
    }
}