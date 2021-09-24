using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;  //키보드,마우스,터치 및 사용자의 입력에 따라 응용 프로그램의
//오브젝트에 이벤트를 보내는 방법

public class Joystick : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{
    private CharacterMoveDirection MoveDirection;
    private Image bgImg;
    private Image joystickImg;
    private Vector3 inputVector;
    
    // Use this for initialization
    void Start () {
        MoveDirection = GetComponent<CharacterMoveDirection>();
        bgImg = GetComponent<Image>();
        joystickImg = transform.GetChild(0).GetComponent<Image>();//자식을 번호로 찾는 방법 : getchild
        
	}
    
    public virtual void OnDrag(PointerEventData ped) //PointerEventData.position : 현재 포인터 위치 PointerEventData : 포인터(마우스/터치) 이벤트와 연관된 이벤트 페이로드
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform,ped.position,ped.pressEventCamera,out pos))
        {
            //RectTransformUtility :RectTransform를 사용하기 위한 헬퍼 메서드가 포함된 유틸리티 클래스 (RectTransform : Transform 컴포넌트의 2d레이아웃 버전 -> ui 요소를 안에 넣을 수 잇는 사각형
            //ScreenPointToLocalPointInRectangle : 스크린 공간 점을 직사각형 평면에있는 RectTransform의 로컬 공간에있는 위치로 변환합니다. 
            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x); //sizeDelta : ui요소의 실제 사각형과 앵커에 의해 정의 된 사각형 사이의 차이를 반환
            //pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);
            inputVector = new Vector3(pos.x * 2 + 1, 0, 0);

            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector; //magnitude :백터의 길이를 반환
            //백터의 길이는 (x * x + y * y + z * z)의 제곱근
            joystickImg.rectTransform.anchoredPosition = new Vector3(inputVector.x * (bgImg.rectTransform.sizeDelta.x / 3), 0f); //joysticklmg를 터치한 좌표값으로 이동
            //앵커 참조 점에 상대적인이 RectTransform 피벗의 위치입니다
        }
    }
    
    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped); //터치하고 있을때 실행이 되도록
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        //터치가 중단
        inputVector = Vector3.zero;
        joystickImg.rectTransform.anchoredPosition = Vector3.zero;
    }

    public float GetHorizontalValue() //플레이어 움직임 주는 부분에서 inputvector의 x값을 받기 위해 사용함
    {
        if (inputVector.x != 0)
            return inputVector.x;
        else
            return Input.GetAxis("Horizontal");
    }

}
