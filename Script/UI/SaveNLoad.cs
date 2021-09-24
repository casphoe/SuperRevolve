using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
public class SaveNLoad : MonoBehaviour
{
    /*
    //public GameObject player;
    [System.Serializable] //Serializable :스크립트 직렬화
                          //직렬화는 클래스나 오브젝트를 스트링이나 일차원 배열형태로 변환하는 것
                          //스크립트에서 만든 클래스의 각종 변수들을 한줄로 늘어서게 한것
                          // 이렇게 한줄로 줄을 세워놓으면 그 데이터를 컴퓨터의 저장장치에 저장 하거나 네트워크로 전달하기에 편리
                          // 오브젝트나 클래스를 한줄로 직렬화 해주는 놈을 시리얼라이저 직렬화된 값을 다시 오브젝트나 클래스 상태로 복원하는 작업을 디시리얼라이즈(deserialize)라고 함
    public class Data
    {
        public int[] StarCount = new int[8]; //별의 개수
        public int sceneName;//이동할 씬의 숫자(nextStage 관련)
        public string MapName; //현재 맵의 이름
        public int ClearNum;
        public StageType stage;
    }
    public Data data;

    private UIManager UI;
    private StageManager TheStage;
    private StarUI StarImage;
    SaveData SaveDB = new SaveData();


    private void Start()
    {
        UI = FindObjectOfType<UIManager>();
        StarImage = FindObjectOfType<StarUI>();
        TheStage = FindObjectOfType<StageManager>();
        //FindObjectOfType : 오브젝트의 형(혹은 컴포넌트의 형)으로 검색해서 가장 처음 나타난 오브젝트 여러개를 GameObject 배열로 반환
    }

    private void Update()
    {
        data.sceneName = SaveData.Scene;
        data.MapName = SaveData.Map;
        data.ClearNum = SaveData.Num;
        data.stage = SaveData.stage;
        for (int i = 0; i < data.ClearNum - 1; i++)
        {
            data.StarCount[i] = SaveData.StarCount[i];
        }
    }
    public void Save() //세이브(저장)
    {
        for (int i = 0; i < TheStage.clearStage; i++)
        {
            data.StarCount[i] = StarImage.Count;
        }
        data.sceneName = UI.sceneNum;
        data.MapName = UI.CurrentMapName;
        data.ClearNum = TheStage.clearStage;
        data.stage = TheStage.stage;
        for (int i = 0; i < TheStage.clearStage; i++)
        {
            SaveData.StarCount[i] = StarImage.Count;
        }
        SaveData.Scene = UI.sceneNum;
        SaveData.Map = UI.CurrentMapName;
        SaveData.Num = TheStage.clearStage;
        SaveData.stage = TheStage.stage;
        BinaryFormatter bf = new BinaryFormatter();
        //BinaryFormatter : 바이너리 형태로 저장하기 위해서 사용하는 방식?
        FileStream file = File.Create(Application.dataPath + "/SaveFile.dat");
        //FileStream : 파일 입출력(클래스)
        bf.Serialize(file, data);
        file.Close(); //파일 닫기
    }


    public void Load() //로드(불러오기)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.dataPath + "/SaveFile.dat", FileMode.Open);
        //FileMode.Open : 기존의 파일을 연다
        if (file != null && file.Length > 0) //파일이 없지 않을때 파일의 길이가 0 초과일때(둘다 만족할때)
                                             //if문을 실행
        {
            data = (Data)bf.Deserialize(file);

            for (int i = 0; i < TheStage.clearStage; i++)
            {
                StarImage.Count = data.StarCount[i];
            }
            UI.sceneNum = data.sceneName;
            UI.CurrentMapName = data.MapName;
            TheStage.clearStage = data.ClearNum;
            TheStage.stage = data.stage;
            for (int i = 0; i < TheStage.clearStage; i++)
            {
                SaveData.StarCount[i] = data.StarCount[i];
                print(SaveData.StarCount[i]);
            }
            SaveData.Scene = data.sceneName;
            SaveData.Map = data.MapName;
            SaveData.Num = data.ClearNum;
            SaveData.stage = data.stage;
            //SceneManager.LoadScene(data.CurrentMapName);
        }
        else
        {
            Debug.Log("저장된 세이브파일이 존재하지 않습니다");
        }
        file.Close();
    }
    */
}