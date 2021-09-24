using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour {

    public GameObject TimePanel;
    private GameObject RetryButton;
    public Text TimeText; //uiText텍스쳐를 받을 Text 변수를 선언
    public float stagecleartime = 0;
    public float remaintime = 0;

    private int Minute = 0; //분 표시
    private float cleartime = 0; //초를 표시
    private UIManager UI;
    // Use this for initialization
    void Start ()
    {
        UI = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        StageTime();
        TimePanel.SetActive(true);  
    }
	
	// Update is called once per frame
	void Update () {       
		if(cleartime != 0) //시간이 0이 아닐때
        {
            cleartime -= Time.deltaTime; // time = time - Time.deltaTime 매프레임 마다(1초당) 시간을 뺌 60초에서 1초가 지나면 59초
            remaintime -= Time.deltaTime;
            if (cleartime >= 60) //초가 60초 이상이 되면
            {
                Minute++; // 분을 증가 1분
                cleartime -= 60; // 초는 0이 되어야함
            }
            if(cleartime < 0) // 시간이 0보다 작을때
            {
                if (Minute > 0)
                {
                    Minute--;
                    cleartime += 60; // 시간을 60초로 돌림
                }               
                if(cleartime <= 0)
                {
                    cleartime = 0;
                    TimePanel.SetActive(false);  // 죽으면 시간이 않보여야함으로 켜져있는 TimePanel를 꺼줌
                    StartCoroutine(Retry(1)); // UI 실행
                }                
            }
        }
        //int t = Mathf.FloorToInt(time); //FloorToInt : /f/로 작거나 같은 가장 큰 정수값을 반환합니다. //1.2 -> 1로 보여줌
        //FloorToInt : 소수점이하 버림 반환값이 int
        TimeText.text = string.Format("{0:00} : {1:00}", Minute, (int)cleartime); // {60초가 되었을때} : {변할값}
        //string.Format : 지정된 형식에 따라 개체의 값을 문자열로 변환하여 다른 문자열에 삽입
    }

    IEnumerator Retry(int time)//시간이 다 되었을때(time = 0) -> Retry가 되어야함
    {
        RetryButton = GameObject.Find("Canvas").transform.Find("GameOver").gameObject; //restart 버튼을 찾음
        yield return new WaitForSeconds(0.3f); //0.3초 후 button를 나옴
        RetryButton.SetActive(true); //버튼 canvas가 보임
        Time.timeScale = 0; //시간을 멈춤
        Debug.Log("죽음");
    }

    void StageTime()
    {
        switch (UI.sceneNum - 2) // UIManager스크립트의 sceneNum(1스테이지가 3)에서 -2를 해줌
        {
            case 1 : stagecleartime = 160; break; // case 1 -> 스테이지 1
            case 2 : stagecleartime = 180; break;
            case 3 : stagecleartime = 180; break;
            case 4 : stagecleartime = 180; break;
            case 5 : stagecleartime = 100; break;
            case 6 : stagecleartime = 240; break;
            case 7 : stagecleartime = 260; break;
            case 8 : stagecleartime = 180; break;
            default : stagecleartime = 360; break;
        }
        cleartime = stagecleartime;
        remaintime = stagecleartime;
    }
}