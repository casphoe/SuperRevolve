using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StageManager : MonoBehaviour
{ //스테이지 관리

   
    private UIManager UI;
    public int clearStage = 1;
    private StageUI StageTP;

    public StageType stage;

    public void StageSelect() //스테이지 선택 // 냅두기
    {
        UI = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        StageTP = GameObject.FindGameObjectWithTag("UIManager").GetComponent<StageUI>();
        switch (stage)
        {
            case StageType.stage1:
                if (stage == StageType.stage1)
                {
                    SceneManager.LoadScene(UI.sceneNum); //첫밴째 씬을 로드
                }
                break;
            case StageType.stage2:
                if (stage == StageType.stage2) //StageClear가 클리어되었을때 또는 _StageSelect 값이 2일때 stage 2를 활성화 하고 stage2를 실행
                {                    
                    SceneManager.LoadScene(UI.sceneNum + 1); //2번째 씬을 불러옴
                }               
                break;
            case StageType.stage3:
                if (stage == StageType.stage3) //StageClear가 클리어되었을때 또는 _StageSelect 값이 2일때 stage 2를 활성화 하고 stage2를 실행
                {                   
                    SceneManager.LoadScene(UI.sceneNum + 2); //2번째 씬을 불러옴
                }
                
                break;
            case StageType.stage4:
                if (stage == StageType.stage4) //StageClear가 클리어되었을때 또는 _StageSelect 값이 2일때 stage 2를 활성화 하고 stage2를 실행
                {                    
                    SceneManager.LoadScene(UI.sceneNum + 3); //2번째 씬을 불러옴
                }
              
                break;
            case StageType.stage5:
                if (stage == StageType.stage5) //StageClear가 클리어되었을때 또는 _StageSelect 값이 2일때 stage 2를 활성화 하고 stage2를 실행
                {                    
                    SceneManager.LoadScene(UI.sceneNum + 4); //2번째 씬을 불러옴
                }
                
                break;
            case StageType.stage6:
                if (stage == StageType.stage6) //StageClear가 클리어되었을때 또는 _StageSelect 값이 2일때 stage 2를 활성화 하고 stage2를 실행
                {                    
                    SceneManager.LoadScene(UI.sceneNum + 5); //2번째 씬을 불러옴
                }
               
                break;
            case StageType.stage7:
                if (stage == StageType.stage7) //StageClear가 클리어되었을때 또는 _StageSelect 값이 2일때 stage 2를 활성화 하고 stage2를 실행
                {
                    SceneManager.LoadScene(UI.sceneNum + 6); //2번째 씬을 불러옴
                }                
                break;
            case StageType.stage8:
                if (stage == StageType.stage8)
                {
                    SceneManager.LoadScene(UI.sceneNum + 7);
                }
                break;
        }
    }
}