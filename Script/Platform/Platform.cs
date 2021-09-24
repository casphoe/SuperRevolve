using UnityEngine;
using System.Collections;

// CharacterMoveDirection에서 public Vector3 inputMoveDirection와 public bool inputJump를 이용함
public class Platform : MonoBehaviour // 좌우이동 버튼을 작동할때 캐릭터가 이동할 방향을 정해줌 (x축 좌우 이동할 것인지 z축 좌우로 움직일 것인지)
{
    public float maxRotationSpeed = 360;
    private CharacterMoveDirection MoveDirection;

    void Awake()
    {
        MoveDirection = GetComponent<CharacterMoveDirection>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        // directionVector로 수평(좌, 우) 입력시 이동하는 방향을 가져옴

        if (directionVector != Vector3.zero) // 수평방향으로 이동할때 (방향벡터가 0이 아닐때) (Vector3.zero는 (0,0,0)을 의미)
        {
            // Get the length of the directon vector and then normalize it
            // Dividing by the length is cheaper than normalizing when we already have the length anyway
            float directionLength = directionVector.magnitude; // 벡터길이를 변환하여 directionLength로 저장
            // 벡터의 길이를 짧게 만들어주기위해 directionVector에 directionLength를나누어줌
            directionVector = directionVector / directionLength;
            // Make sure the length is no bigger than 1
            // 길이기 1보다 작은지 확인하고 둘중 작은값을 directionLength에 저장
            directionLength = Mathf.Min(1, directionLength);
            // Make the input vector more sensitive towards the extremes and less sensitive in the middle
            // This makes it easier to control slow speeds when using analog sticks
            // 이동할때 느린속도로 조절하기 쉽게하기위해 directionLength에 directionLength를 곱함
            directionLength = directionLength * directionLength;
            // Multiply the normalized direction vector by the modified length
            // 정규화된 벡터directionVector에 directionLength를 곱함
            directionVector = directionVector * directionLength;
        }

        // Rotate the input vector into camera space so up is camera's up and right is camera's right
        // 입력 벡터를 카메라 공간으로 회전함. 그래 카메라의 왼쪽과 오른쪽 방향은 벡터의 왼쪽과 오른쪽방향이 됨.
        directionVector = Camera.main.transform.rotation * directionVector;

        // Rotate input vector to be perpendicular to character's up vector
        // 입력 벡터를 문자의 위쪽 벡터에 수직으로 회전
        Quaternion camToCharacterSpace = Quaternion.FromToRotation(-Camera.main.transform.forward, transform.up);
        directionVector = (camToCharacterSpace * directionVector);

        // Apply the direction to the CharacterMoveDirection
        MoveDirection.inputMoveDirection = directionVector;
        
    }

}