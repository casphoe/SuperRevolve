using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarUI : MonoBehaviour { //클리어 시간에 따라서 별의 개수를 표현

    public Image StarImage; //별의 이미지의 오브젝트를 받을 배열
    public Sprite[] StarSprite = new Sprite[3]; //별의 스프라이트 이미지를 받을 배열
	public int Count = 0;

    private Timer TheTime;

    public void ChangeStarImage() //시간에 따라서 별의 숫자를 변화
    {
        TheTime = GameObject.FindGameObjectWithTag("UIManager").GetComponent<Timer>();
        if(TheTime.remaintime >= (TheTime.stagecleartime * 0.5f))
        {
            StarImage.sprite = StarSprite[2];
            Count = 3;
            StarSave();
        }
        else if(TheTime.remaintime >= (TheTime.stagecleartime * 0.25f))
        {
            StarImage.sprite = StarSprite[1];
            if (SaveData.StarCount[SaveData.ThisStage - 1] < 3)
            {
                Count = 2;
                StarSave();
            }
        }
        else if(TheTime.remaintime > 0)
        {
            StarImage.sprite = StarSprite[0];
            if (SaveData.StarCount[SaveData.ThisStage - 1] < 2)
            {
                Count = 1;
                StarSave();
            }
        }
    }

    private void StarSave()
    {
        SaveData.StarCount[SaveData.ThisStage - 1] = Count;
    }

}