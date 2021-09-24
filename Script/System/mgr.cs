using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mgr : Language
{


    void Start () {

        GameObject Help1_Kor;
        GameObject Help1_Eng;

        GameObject Help2_Kor;
        GameObject Help2_Eng;

        GameObject Help3_Kor;
        GameObject Help3_Eng;

        GameObject Help4_Kor;
        GameObject Help4_Eng;

        GameObject Help5_Kor;
        GameObject Help5_Eng;

        GameObject Help6_Kor;
        GameObject Help6_Eng;

        Help1_Kor = GameObject.Find("Answer1").transform.Find("KoreanText").gameObject;
        Help1_Eng = GameObject.Find("Answer1").transform.Find("EnglishText").gameObject;

        Help2_Kor = GameObject.Find("Answer2").transform.Find("KoreanText").gameObject;
        Help2_Eng = GameObject.Find("Answer2").transform.Find("EnglishText").gameObject;

        Help3_Kor = GameObject.Find("Answer3").transform.Find("KoreanText").gameObject;
        Help3_Eng = GameObject.Find("Answer3").transform.Find("EnglishText").gameObject;

        Help4_Kor = GameObject.Find("Answer4").transform.Find("KoreanText").gameObject;
        Help4_Eng = GameObject.Find("Answer4").transform.Find("EnglishText").gameObject;

        Help5_Kor = GameObject.Find("Answer5").transform.Find("KoreanText").gameObject;
        Help5_Eng = GameObject.Find("Answer5").transform.Find("EnglishText").gameObject;

        Help6_Kor = GameObject.Find("Answer6").transform.Find("KoreanText").gameObject;
        Help6_Eng = GameObject.Find("Answer6").transform.Find("EnglishText").gameObject;

        Debug.Log(i);

        switch (i)
        {
            case 0:// 한국어
                Help1_Kor.gameObject.SetActive(true);
                Help1_Eng.gameObject.SetActive(false);

                Help2_Kor.gameObject.SetActive(true);
                Help2_Eng.gameObject.SetActive(false);

                Help3_Kor.gameObject.SetActive(true);
                Help3_Eng.gameObject.SetActive(false);

                Help4_Kor.gameObject.SetActive(true);
                Help4_Eng.gameObject.SetActive(false);

                Help5_Kor.gameObject.SetActive(true);
                Help5_Eng.gameObject.SetActive(false);

                Help6_Kor.gameObject.SetActive(true);
                Help6_Eng.gameObject.SetActive(false);

                break;

            case 1:// 영어

                Help1_Kor.gameObject.SetActive(false);
                Help1_Eng.gameObject.SetActive(true);

                Help2_Kor.gameObject.SetActive(false);
                Help2_Eng.gameObject.SetActive(true);

                Help3_Kor.gameObject.SetActive(false);
                Help3_Eng.gameObject.SetActive(true);

                Help4_Kor.gameObject.SetActive(false);
                Help4_Eng.gameObject.SetActive(true);

                Help5_Kor.gameObject.SetActive(false);
                Help5_Eng.gameObject.SetActive(true);

                Help6_Kor.gameObject.SetActive(false);
                Help6_Eng.gameObject.SetActive(true);

                break;
        }
    }


}

