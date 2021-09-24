using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StageType
{
    stage1, stage2, stage3, stage4, stage5, stage6, stage7, stage8
}

public class StageUI : MonoBehaviour
{
    //private SaveNLoad TheSaveNLoad;
    public Image[] StageImage = new Image[8]; //스테이지 이미지
    public Sprite StageSprite; //스테이지 스프라이트(스테이지 클리어가 되었을때 이미지를 변화를 주기위해서)

    private StarUI TheStar; // 냅두기
    private StageManager TheStage;
    private UIManager UI;

    public Image[] StageStarImage = new Image[8];

    public Button[] StageButton = new Button[8];

    public StageType Stage;

    public SaveData DB;

    // Use this for initialization
    void Start()
    {
        TheStar = GameObject.FindGameObjectWithTag("UIManager").GetComponent<StarUI>(); // 냅두기
        //TheSaveNLoad = GameObject.FindGameObjectWithTag("UIManager").GetComponent<SaveNLoad>();
        TheStage = FindObjectOfType<StageManager>();
        UI = FindObjectOfType<UIManager>();
        ImageChange();
        //ButtonControl();
        //Stage = SaveData.stage;
        StageImageLook();
    }

    private void Update()
    {
        //Stage = SaveData.stage;
        //StageImageLook();
    }
    
    //별의 개수의따라서 별의 이미지가 변화(스테이지 상)
    
    void ImageChange()
    {
        for (int i = 0; i < SaveData.FinalStage; i++)
        {
            if (SaveData.StarCount[i] > 2) //count가 3이 되면 별의 이미지의 개수가 3개가 차있는 모습
            {
                StageStarImage[i].GetComponent<Image>().enabled = true;
                StageStarImage[i].sprite = TheStar.StarSprite[2]; // 냅두기
            }
            else if (SaveData.StarCount[i] == 2) //별의 이미지가 2개가 차있는 모습으로 나타남	
            {
                StageStarImage[i].GetComponent<Image>().enabled = true;
                StageStarImage[i].sprite = TheStar.StarSprite[1]; // 냅두기
            }
            else if (SaveData.StarCount[i] == 1) //별의 이미지가 1개가 차있는 모습
            {
                StageStarImage[i].GetComponent<Image>().enabled = true;
                StageStarImage[i].sprite = TheStar.StarSprite[0]; // 냅두기
            }
            else
            {
                StageStarImage[i].GetComponent<Image>().enabled = false;
            }
        }
        /*
        for (int i = 0; i < 8; i++)
        {
            
            if (SaveData.StarCount[i] > 2) //count가 3이 되면 별의 이미지의 개수가 3개가 차있는 모습
            {
                for (int k = 0; k < ; k++)
                {
                    StageStarImage[k].GetComponent<Image>().enabled = true;
                    StageStarImage[k].sprite = TheStar.StarSprite[2]; // 냅두기
                }
            }
            else if (SaveData.StarCount[i] == 2) //별의 이미지가 2개가 차있는 모습으로 나타남	
            {
                for (int k = 0; k < ; k++)
                {
                    StageStarImage[k].GetComponent<Image>().enabled = true;
                    StageStarImage[k].sprite = TheStar.StarSprite[1]; // 냅두기
                }
            }
            else if (SaveData.StarCount[i] == 1) //별의 이미지가 1개가 차있는 모습
            {
                for (int k = 0; k < ; k++)
                {
                    StageStarImage[k].GetComponent<Image>().enabled = true;
                    StageStarImage[k].sprite = TheStar.StarSprite[0]; // 냅두기
                }
            }
        }
        */
    }

    public void StageImageLook() //이미지 상태값 변화
    {
        switch (SaveData.FinalStage)
        {
            case 1:
                {
                    for (int i = 0; i < 1; i++)
                    {
                        StageImage[i].sprite = StageSprite;
                        StageButton[i].GetComponent<Button>().enabled = true;
                    }
                    break;
                }
            case 2:
                for (int i = 0; i < 2; i++)
                {
                    StageImage[i].sprite = StageSprite;
                    StageButton[i].GetComponent<Button>().enabled = true;
                }
                
                break;
            case 3:
                for (int i = 0; i < 3; i++)
                {
                    StageImage[i].sprite = StageSprite;
                    StageButton[i].GetComponent<Button>().enabled = true;
                }
                break;
            case 4:
                for (int i = 0; i < 4; i++)
                {
                    StageImage[i].sprite = StageSprite;
                    StageButton[i].GetComponent<Button>().enabled = true;
                }
                break;
            case 5:
                for (int i = 0; i < 5; i++)
                {
                    StageImage[i].sprite = StageSprite;
                    StageButton[i].GetComponent<Button>().enabled = true;
                }
                break;
            case 6:
                for (int i = 0; i < 6; i++)
                {
                    StageImage[i].sprite = StageSprite;
                    StageButton[i].GetComponent<Button>().enabled = true;
                }
                break;
            case 7:
                for (int i = 0; i < 7; i++)
                {
                    StageImage[i].sprite = StageSprite;
                    StageButton[i].GetComponent<Button>().enabled = true;
                }
                break;
            case 8:
                for (int i = 0; i < 8; i++)
                {
                    StageImage[i].sprite = StageSprite;
                    StageButton[i].GetComponent<Button>().enabled = true;
                }
                break;
        }
    }
}