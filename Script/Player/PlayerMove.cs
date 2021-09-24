using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {

    public Joystick joystick; //조이스틱 스크립트
    public bool Flip = false;
    public bool AnimationStart = false;

    private Vector3 moveDir;
    private Vector3 directionVector;
    private Vector3 _PlayerMoveVector; //플레이어 이동백터
    private Transform _target;
    private CharacterMoveDirection MoveDirection;
    private float mSpeed = 0.7f; //플레이어 이동 속도

    void Start()
    {
        MoveDirection = GetComponent<CharacterMoveDirection>();
        _target = transform;
        _PlayerMoveVector = Vector3.zero; //플레이어 이동백터 초기화
    }

    void Update() //프레임마다 한번씩 호출
    {
        //터치 패드 입력받기
        HandleInput();
        if (joystick.GetHorizontalValue() > 0 && enabled == false)
        {
            _PlayerMoveVector = Vector3.zero;
        }
        if (joystick.GetHorizontalValue() < 0 && enabled == false)
        {
            _PlayerMoveVector = Vector3.zero;
        }
    }
    void FixedUpdate() //프레임 속도가 낮은 경우 프레임마다 여러번 호출 가능 프레임 속도가 높을 경우 프레임간에 호출 불가능
    {
        //플레이어 이동
        Move();
    }

    public void HandleInput()
    {
        _PlayerMoveVector = PoolInput();
    }
    
    public Vector3 PoolInput()
    {        
        float h = joystick.GetHorizontalValue(); //왼쪽 오른쪽 값 나타냄
        //horizontal 왼쪽 오른쪽 Vertical 위 아래
        //Vector3 moveDir = MoveDirection.inputMoveDirection.normalized; //백터값을 정규화함
        //moveDir = new Vector3(h, 0, 0).normalized;
        if(h > 0 && enabled == true)
        {
            Direction(1, 0, 0);
            Flip = false;
            AnimationStart = true;
        }
        if (h < 0 && enabled == true)
        {
            Direction(-1, 0, 0);
            Flip = true;
            AnimationStart = true;
        }
        if (h == 0)
        {
            Direction(0, 0, 0);
            AnimationStart = false;
        }
        //normalized : 해당 백터의 magnitude가 1인 백터를 반환 -> 백터는 값은 방향값을 갖지만 정규화 백터의 길이는 1.0
        return moveDir; //moveDir 반환
    }

    private void Direction(int x, int y, int z) // 조이스틱 움직임에따라 캐릭터가 움직이는 방향을 결정해주는 기능
    {
        Vector3 directionVector = new Vector3(x, y, z);
        directionVector = Camera.main.transform.rotation * directionVector;
        MoveDirection.inputMoveDirection = directionVector;
        moveDir = MoveDirection.inputMoveDirection.normalized * 4.5f; //백터값을 정규화함
    }

    public void Move()
    {
        _target.Translate(_PlayerMoveVector * mSpeed * Time.deltaTime); //target의 위치를 이동
    }

    public void disable() // 캐릭터 못움직이게 하는 함수
    {
        enabled = false; // CharacterMotor의 public bool enabled를 false로 만들어서 움직이는 동작이 실행되지 않게 만들어줌
        this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }

    public void enable() // 캐릭터 움직일수 있게 해주는 함수
    {
        enabled = true; // CharacterMotor의 public bool enabled를 true로 만듬
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }

}
