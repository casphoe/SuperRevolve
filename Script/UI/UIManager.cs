using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    private bool pauseOn = false; //버튼이 눌렸는지 확인하는 변수
    private GameObject Panel; //Panel를 받아올 변수   
    public int sceneNum; //이동할 씬의 숫자
    public string CurrentMapName; //현재 맵의 이름
   
    public GameObject ClearPanel;
    private GameObject QuestPanel; //QuestPanel(꺼저있는 도움말 패널의)오브젝트를 받는 변수
    private SaveNLoad TheSaveNLoad;
    private GameObject Quest;
    private GameObject OptionPanel;

    private void Update()
    {
        SaveData.ThisStage = sceneNum - 2;
    }

    public void ActivePauseButtonClick() //일시 정지 버튼을 눌렸을때
    {
        Panel = GameObject.Find("Canvas").transform.Find("PauseMenu").gameObject; //시작할때 pausePanel의 게임오브젝트를 찾음 canvas의 자식으로 되어있으므로 자식의 이름을 찾는 findchild를 사용
        if (!pauseOn) //일시정지 버튼을 눌렸을때
        {
            Time.timeScale = 0; //시간 흐림 비율을 0으로
                                //Time.timeScale 게임내 시간이 흐르는 속도와 관계가 있는 변수 1이면 1배속 0이면 0배속
            Panel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            Panel.SetActive(false); //일시정지할때만 보여야해서 않보이게 꺼줌
        }
        pauseOn = !pauseOn;
    }

    public void MainMenuButtonOnClick()
    {
        Debug.Log("메인 메뉴로 돌아가기");
        Time.timeScale = 1.0f; // 시간을 초기상태로 돌려줌 1.0배속인
        SceneManager.LoadScene(0);        
        //Application.LoadLevel("StartScene"); //메인화면으로 되돌아감
        //Application : 어플리케이션의 동적 데이터에(run-time data)로 접근
        //Application.LoadLevel : 이름 또는 인덱스에 따라 레벨을 로드
    }
    public void QuitButtonOnClick()
    {
        Application.Quit(); //게임종료
        //Application.Quit : 응용프로그램 종료
    }

    public void OnStartButton()
    {
        SceneManager.LoadScene(1); //ScreenLoader의 이름의 씬을 불러옴
    }

    public void ReStartOnclick() //일시정지 버튼에서 눌렀을때 모든것이 초기화되고 현재맵에서 다시 시작
    {
        Debug.Log("게임 재시작");
        //SceneManager.LoadScene(CurrentMapName); //현재 맵에서 다시 시작하기
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }
   
    public void NextStageButton() //다음 스테이지 가는 버튼
    {
        if(!pauseOn)
        {
            ClearPanel.gameObject.SetActive(false);
            SceneManager.LoadScene(sceneNum);
            //StartCoroutine(AddScene(1)); //AddScene의 코루틴을 한번 시작함
            Time.timeScale = 1f;
        }       
    }

    public void SaveButton()
    {
        Time.timeScale = 0f;
        //TheSaveNLoad = FindObjectOfType<SaveNLoad>();
        //TheSaveNLoad.Save();
    }

    public void QuestButton() //도움말 버튼
    {
        QuestPanel = GameObject.Find("MainMenu").transform.Find("QuestPanel").gameObject;
        Quest = GameObject.Find("QuestButton");
        QuestPanel.gameObject.SetActive(true);
        Quest.gameObject.SetActive(false);
    }

    public void QuestExitButton()
    {
        QuestPanel.gameObject.SetActive(false);
        Quest.gameObject.SetActive(true);
    }

    
	public void StageSelectSecneButton()
	{
		//TheSaveNLoad = FindObjectOfType<SaveNLoad>();
		//TheSaveNLoad.Load();
		SceneManager.LoadScene(sceneNum);		
	}

}