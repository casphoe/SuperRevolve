using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    public CanvasGroup HelpGroup; // 표지판 내용(캔버스 그룹)

    private bool On = false;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player") //플레이어라는 태그와 부딪쳤을때
        {
            On = true;
            StartCoroutine(AnswerPanelOpen(1)); //AnswerPanelOpen이라는 코루틴을 한번만 실행
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") // 플레이어라는 태그와 부딪쳤을때
        {
            On = false;
            StartCoroutine(AnswerPanelExit(1));
        }
    }

    IEnumerator AnswerPanelOpen(int num) // 투명 -> 불투명
    {
        while (HelpGroup.alpha < 1 && (On == true))
        {
            HelpGroup.alpha += Time.deltaTime / 0.5f;
            yield return null;
            if (HelpGroup.alpha > 1)
            {
                yield return null;
                break;
            }
        }
    }

    IEnumerator AnswerPanelExit(int num) // 불투명 -> 투명
    {
        while (HelpGroup.alpha > 0 && (On == false))
        {
            HelpGroup.alpha -= Time.deltaTime / 0.5f;
            yield return null;
            if (HelpGroup.alpha < 0)
            {
                yield return null;
                break;
            }
        }
    }

}