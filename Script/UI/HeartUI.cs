using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HeartUI : MonoSingletonBase<HeartUI> //heartUI 싱글톤 
{      
    private int curHealth = 3;
    public Image[] HeartImage = new Image[3]; //이미지의 오브젝트를 받을 배열
    public Sprite[] HealthSprites = new Sprite[3]; //sprite의 이미지를 받을 배열

    void Start()
    {
        curHealth = 6; //1일때는 half 2일때는 이런방식을 주기 위해서 curHealth에 startHealth의 값에다가 곱해야함
        //CheckHealthAmout(); //checkHealtAmout함수를 실행
    }

    private void Update()
    {
        UpdateHearts();
    }

    public void UpdateHearts() //heart이미지 변화
    {
        bool empty = false; //empty를 거짓과 참으로 판단하는 변수 bool형으로 선언 empty는 HeartImage가 다 비어있는지 판단하는 bool형인것 같음
        int i = 0;
        foreach(Image image in HeartImage) //HeartImage의 있는 이미지들을 HealthSprites에 있는 sprite로 변화
                                           //HeartImage 배열까지(0~2)까지 탐색 foreach 문은 무조건, 처음부터 끝까지 즉, 멤버 전체를 순회한다(반복문)
        {
            if (empty)
            {
                image.sprite = HealthSprites[0];  //이미지 스크립트를 HealthSprites[0]에 잇는 스크립트로 변환
            }
            else
            {
                i++;
                if(curHealth >= i * 2) //curHealth 현재의 체력값이 i값과 2 값의(2) 곱한것보다 크거나 같을때 -> 최대 i = 3까지 돌음
                {
                    image.sprite = HealthSprites[HealthSprites.Length - 1]; //이미지 sprite를 HealthSprites[0]~ HealthSprites[1]까지 돌음 즉 halfHeart랑 emptyHeart까지 게속 돌아감 i = 3이 되기전까지
                }
                else //if문이 아닌경우 (curHealth < i * 2)인 경우
                {
                    int currentHeartHeat = (int)(2 - (2 * i - curHealth)); //currentHeartHeat에 (2 - (2 * i - curHealth))의 int값을 대입
                    int healthPerImage = 2 / (HealthSprites.Length - 1); //healthPerImage : [0]~[2]까지의 값이 나옴
                    int imageIndex = currentHeartHeat / healthPerImage;
                    image.sprite = HealthSprites[imageIndex]; //이미지의 스크립트를 HealthSprites의 imageIndex의 배열값만큼 변화 ex: image.sprite = HealthSprites[0] 등으로 표현이 가능
                    empty = true; //empty를 true로 변경
                }
            }
        }
    }

    public void TakeDamage(int amout) //데미지 입었을때 표현
    {
        curHealth -= amout; //curHealth 값에 amout 값을 뺌
        curHealth = Mathf.Clamp(curHealth, 0, 6); //curHealth Mathf.Clamp 최소 /최대값을 설정하여 값이 범위 이외의 값을 넘지 않도록 함 curHealth가 범위 최소가 0 최대가 startHealth * 2 값
        UpdateHearts(); //UpdateHearts()의 함수를 실행
    }

}
