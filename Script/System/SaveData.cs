using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour {

	public static int[] StarCount = new int[8]; //스테이지마다 별의 개수로 이미지를 변화를 주기위해서 사용하는 int형 배열
    public static int ThisStage = 0; // 현재 스테이지 번호
    public static int FinalStage = 1; // 선택할수있는 가장 마지막 스테이지 번호

}
