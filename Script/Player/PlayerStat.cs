using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStat : MonoBehaviour {

    public float currentHp = 3f; //캐릭터의 현재 체력
    private bool isDead = false;
    private bool isDamage = false;
    private GameObject RetryButton;
    private ScoreManager _score;
    private GameObject Portal; //포탈의 관련된 게임 오브젝트(포탈 파티클레이어 밑에 있는 박스 콜라인더) 다음 씬으로 가게해주는 장치
    public float diePosition = 0; //플레이어가 죽는 위치(currentHp가 0이 아니라도) 이 위치가 아래가 되면 죽음
    // Use this for initialization
    void Start()
    {
        Portal = GameObject.Find("Portal"); //포탈이라는 게임오브젝트를 찾음
        Portal.gameObject.SetActive(false); //포탈을 게임오브젝트를 꺼줌
    }

    void Update()
    {        
        Die();
    }

    IEnumerator Retry(int time)//플레이어가 죽었을때 발생하는 함수 GameOver panel 나타나고 그 버튼을 눌렀을때 게임화면으로 다시 시작해야함
    {
        RetryButton = GameObject.Find("Canvas").transform.Find("GameOver").gameObject; //GameOver이라는 panel를 찾음 (죽었을때)
        yield return new WaitForSeconds(0.3f); //0.3초 후 button를 나옴
        RetryButton.SetActive(true); //버튼 canvas가 보임
        Time.timeScale = 0; //시간을 멈춤
        GameObject.Find("die").GetComponent<AudioSource>().Play();

    }

    public void Die()
    {
        if(currentHp == 0 || diePosition > this.gameObject.transform.position.y) //hp가 0이 되거나 자기자신의 y의 위치가 diePosition이라는 정해진 위치보다 낮아지게 되면 죽음
        {                    
            StartCoroutine(Retry(1)); //GameOver 가 되는 panel이 나타나지는 코루틴을 한번 실행
        }
    }

    private void OnTriggerEnter(Collider other) //충돌처리 (아이템)
    {
        _score = GameObject.FindGameObjectWithTag("UIManager").GetComponent<ScoreManager>(); //UIManager라는 태그를 가진 오브젝트의 ScoreManager이라는 스크립트를 불려옴

        if (other.gameObject.name == "Cherry") //Cherry라는 태그의 이름을 가진 것을 부딪쳤을때 밑에 문장을 실행
        {
            _score.EatCherry(1);
            Destroy(other.gameObject, 0);
            //GameObject.Find("apple").GetComponent<AudioSource>().Play();

        }
        if (other.gameObject.name == "Apple")
        {
            _score.EatApple(1);
            Destroy(other.gameObject, 0);
            //GameObject.Find("apple").GetComponent<AudioSource>().Play();

        }
        if (other.gameObject.name == "Lemon")
        {
            _score.EatLemon(1); //1만큼증가
            Destroy(other.gameObject, 0);
            //GameObject.Find("apple").GetComponent<AudioSource>().Play();

        }
        if (_score.Cherry == 1 && _score.Apple == 1 && _score.Lemon == 1) //체리랑 사과 레몬을 각각 1개를 전부다 먹었을때 포탈이 열리게 설정
        {
            Portal.gameObject.SetActive(true);
        }
    }

}