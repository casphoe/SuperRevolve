using UnityEngine;
using System.Collections;

// DisablePlayer스크립트의 disable (), enable () 를 사용하여 화면회전중에 캐릭터 움직임을 멈추게하고 회전이 끝난후 다시 움직이도록함
// 회전할때마다 crunchCollidersToPlayer() [플랫폼 콜라이더 위치 결정] 함수를 실행해줌
class CameraRotator : MonoBehaviour // 카메라 회전기능 클래스 (CrunchPlatformColliders, DisablePlayer와 연동되는 클래스) + 플랫폼맵 콜라이더 위치 결정해주는 클래스
{
    public bool turn = false;
    public int RotationAngle = 0;

    private PlayerMove PlayerMove = null; // PlayerMove라는 PlayerMove 선언
    private GameObject Player = null;
    private GameObject Obstacle = null;
    private GameObject[] allPlatforms = null;

    private float rotateTime = 1.0f; // 카메라 회전시간
    private bool isTweening = false; // 카메라 회전 여부 (카메라 회전해주는 iTween작동 여부를 판단하기위해 만들어진것)

    private void Start()
    {
        RotationAngle = 0;
        turn = false;
        Player = GameObject.FindGameObjectWithTag("Player"); // "Player"라는 이름의 Tag를 가진 게임오브젝트를 찾아서 player라고 선언
        Obstacle = GameObject.Find("Obstacle");
        allPlatforms = GameObject.FindGameObjectsWithTag("Platform");
        PlayerMove = Player.GetComponentInChildren<PlayerMove>();
        setPlayerPos(); // 캐릭터위치 설정
        crunchCollidersToPlayer(); // 캐릭터위치에 따라 콜라이더 위치 설정
    }

    private void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Input.GetKeyDown(KeyCode.Z)) // Z키를 누른다면
        {
            rotateTween(90); // 90도 회전 (카메라를 회전시키는 함수 실행)
        }
        if (Input.GetKeyDown(KeyCode.X)) // x키를 누른다면
        {
            rotateTween(-90); // -90도 회전 (카메라를 회전시키는 함수 실행)
        }
    }

    private void rotateTween(float amount) // ITween을 사용하여 카메라를 회전시키는 함수 (amount라는 float는 카메라 회전 각도)
    {
        if (isTweening == false) // 카메라 회전 여부 가 거짓일때
        {
            isTweening = true; // 카메라 회전 여부 참
            setPlayerPos(); // 회전에 따라 캐릭터 위치 결정
            PlayerMove.disable(); // 캐릭터 움직임을 막기
            Vector3 rot = new Vector3(0, amount, 0); // y축으로 amount을 rot라는 Vector3에 저장
            // 회전하는 iTween기능 (RotateAdd) 사용
            iTween.RotateAdd
                (gameObject, iTween.Hash // 주어진 오일러 각을 주어진 시간에 따라 회전시키는 기능
                    (
                    "time", rotateTime, // time, rotateTime -> 카메라 회전시간 [애니메이션이 완료되는데 걸리는 시간]
                    "amount", rot, // amount, rot -> Vector3 회전 [GameObject의 현재 회전에 추가 할 오일러 각의 각도]
                    "easetype", iTween.EaseType.easeInOutSine, // easetype, -> iTween.EaseType.easeInOutSine easeInOutSine이라는 방식으로 회전 [애니메이션에 적용될 형태]
                    "oncomplete", "onColorTweenComplete" // oncomplete->iTween 애니메이션이 끝난뒤에 onColorTweenComplete라는 이름의 함수 실행 [애니메이션의 끝에서 시작될 함수의 이름]
                    )
                );
            ObstacleOff();
            Turning();
            RotationWorld();

            //GameObject.Find("rotation").GetComponent<AudioSource>().Play();

        }
    }

    private void onColorTweenComplete()
    {
        isTweening = false; // 카메라 회전 여부 거짓
        PlayerMove.enable(); // 캐릭터 움직임 허용시켜주기
        crunchCollidersToPlayer(); // 플랫폼 콜라이더를 캐릭터좌표로 위치 결정
        ObstacleOn();
    }

    public void RotateButton()
    {
        rotateTween(90); // 90도 회전 (카메라를 회전시키는 함수 실행)
    }

    private void setPlayerPos() // 회전에 따라 캐릭터 위치 결정
    {
        // player라고 선언된오브젝트의 위치값에서 Vector3.down(0, -1, 0) * 100 위치의 방향으로 나가는 선분 ray를 선언
        Ray ray = new Ray(Player.transform.position, Vector3.down);
        RaycastHit hit = new RaycastHit(); // Ray가 충돌되었다는것을 알수있게 해주는 장치 
        // ray가 100.0f길이만큼 발사되어 충돌된다면 -> (ray(Ray 발사할 위치, Ray 발사 방향), 충돌결과(out이 참조해주는 형식이고 hit가 출동여부 확인), Ray가 발사되는 최대길이)
        // out을 사용할때 뒤에올것은 미리 선언되어 있어야만 한다. (바로 앞에 RaycastHit hit = new RaycastHit(); 문장이 있는 이유)
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            GameObject platform = hit.collider.gameObject; // ray와 충돌된 콜라이더를 가진 게임오브젝트를 platform이라는 이름의 게임오브젝트로 저장
            Vector3 colliderPos = ((BoxCollider)hit.collider).center; // ray와 충돌된 (BoxCollider)콜라이더의 중심좌표를 colliderPos라는 Vector3형식으로 저장
            // ray와 충돌된 플랫폼 좌표를 (캐릭터의 위치좌표를 로컬좌표에서 월드좌표로 변환한 좌표)로 변환한 좌표를 playerPos라는 Vector3로 저장
            Vector3 playerPos = platform.transform.InverseTransformPoint(Player.transform.position);
            // 캐릭터(월드좌표)의 x, z좌표에서 콜라이더의 x, z좌표의 거리를 뺀값(y좌표는 캐릭터좌표 그대로)을 newPos라는 Vector3로 저장 
            Vector3 newPos = new Vector3(playerPos.x - colliderPos.x, playerPos.y, playerPos.z - colliderPos.z);
            newPos = platform.transform.TransformPoint(newPos); // (newPos)라는 로컬좌표를 월드좌표로 값으로 바꿨을때 나온 좌표를 newPos에 저장
            Player.transform.position = newPos; // 캐릭터좌표가 newPos로 이동
        }
    }

    private void crunchCollidersToPlayer() // 플랫폼 콜라이더를 캐릭터좌표로 위치 결정
    {
        Transform playerTrans = Player.transform; // 캐릭터의 transform (위치, 회전, 크기 정보)를 playerTrans라는 이름으로 저장
        allPlatforms = GameObject.FindGameObjectsWithTag("Platform"); // "Platform"라는 이름의 Tag를 가진 게임오브젝트를 모두 찾아서 allPlatforms 라고 배열로 선언
        int numPlatforms = allPlatforms.Length; // "Platform"라는 이름을 가진 플랫폼의 개수를 numPlatforms에 저장
        for (int i = 0; i < numPlatforms; i++)
        { // 반복문 (플랫폼 개수만큼)
            GameObject platform = allPlatforms[i]; // platform 이름의 게임오브젝트를 allPlatforms[i번째]로 지정
            // 지정된 플랫폼의 컴포넌트인 BoxCollider를 가져와서 collider라는 이름의 Boxcollider로 저장 
            BoxCollider collider = platform.GetComponentInChildren<BoxCollider>();
            collider.center = Vector3.zero; // collider의 중심을 Vector3.zero(0, 0, 0)으로 지정

            //convert pos vec into world space
            // 플랫폼의 BoxCollider의 중심위치를 colliderPos라는 Vector3로 저장
            Vector3 colliderPos = collider.transform.TransformPoint(collider.center);
            Vector3 playerPos = playerTrans.position; // 캐릭터의 위치를 playerPos라는 Vector3로 저장
            Vector3 newColliderPos; // 새 플랫폼 Collider의 위치를 선언 // 이 Vector3에 캐릭터의 좌표와 플랫폼의 좌표일부가 들어갈예정

            //move platform collider depending on what side the camera is facing 
            Vector3 normalCam = Camera.main.transform.position.normalized;
            // (normalCam -> 카메라 위치 정규화)
            if (Mathf.Abs(Mathf.Round(normalCam.x)) == 1.0f) // normalCam.x를 반올림한 값의 절대값이 1이면
                newColliderPos = new Vector3(playerPos.x, colliderPos.y, colliderPos.z);
            else
                newColliderPos = new Vector3(colliderPos.x, colliderPos.y, playerPos.z);

            //converts back into local space
            newColliderPos = collider.transform.InverseTransformPoint(newColliderPos);
            collider.center = newColliderPos; // 콜라이더 중심은 newColliderPos
        }
    }

    private void Turning()
    {
        if (turn == false)
        {
            turn = true;
        }
        else
            turn = false;
    }

    private void RotationWorld()
    {
        RotationAngle = RotationAngle + 90;
        if (RotationAngle >= 360)
        {
            RotationAngle = 0;
        }
    }

    private void ObstacleOff()
    {
        foreach (Transform child in Obstacle.transform)
        {
            child.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void ObstacleOn()
    {
        foreach (Transform child in Obstacle.transform)
        {
            child.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

}
